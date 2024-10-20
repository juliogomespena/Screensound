using ScreenSound.Entidades;

namespace ScreenSound.Menus;

internal class MenuAvaliarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Avaliar uma música");
        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write("Qual nome do álbum ao qual a música pertence: ");
            string nomeDoAlbum = Console.ReadLine()!;
            if (bandasRegistradas[nomeDaBanda].Albuns.ContainsKey(nomeDoAlbum))
            {
                Console.Write("Qual o nome da música que deseja avaliar: ");
                string nomeDaMusica = Console.ReadLine()!;
                if (bandasRegistradas[nomeDaBanda].Albuns.Values.First(a => a.Nome == nomeDoAlbum).Musicas.Any(m => m.Nome == nomeDaMusica))
                {
                    Console.Write($"Qual a nota (0 - 10) que a música {nomeDaMusica} merece: ");
                    int nota = int.Parse(Console.ReadLine()!);
                    bandasRegistradas[nomeDaBanda].Albuns.Values.First(a => a.Nome == nomeDoAlbum).Musicas.First(m => m.Nome == nomeDaMusica).Avaliacao.AdicionarNota(nota);
                    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para o álbum {nomeDoAlbum}");
                }
                else
                    Console.WriteLine($"\nA música {nomeDaMusica} não foi encontrada!");
            }
            else
                Console.WriteLine($"\nO álbum {nomeDoAlbum} não foi encontrado!");
        }
        else
            Console.WriteLine($"\nA musica {nomeDaBanda} não foi encontrada!");

        base.Executar(bandasRegistradas);
    }
}
