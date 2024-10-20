using ScreenSound.Entidades;

namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Avaliar um álbum");
        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write("Qual nome do álbum que deseja avaliar: ");
            string nomeDoAlbum = Console.ReadLine()!;
            if (bandasRegistradas[nomeDaBanda].Albuns.ContainsKey(nomeDoAlbum))
            {
                Console.Write($"Qual a nota (0 - 10) que o álbum {nomeDoAlbum} merece: ");
                int nota = int.Parse(Console.ReadLine()!);
                bandasRegistradas[nomeDaBanda].Albuns.Values.First(a => a.Nome == nomeDoAlbum).Avaliacao.AdicionarNota(nota);
                Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para o álbum {nomeDoAlbum}");
            }
            else
                Console.WriteLine($"\nO álbum {nomeDoAlbum} não foi encontrado!");
        }
        else
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");

        base.Executar(bandasRegistradas);
    }
}
