using ScreenSound.Entidades;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Registrar uma música");
        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write("Qual nome do álbum ao qual deseja adicionar uma música: ");
            string nomeDoAlbum = Console.ReadLine()!;
            if (bandasRegistradas[nomeDaBanda].Albuns.ContainsKey(nomeDoAlbum))
            {
                Console.Write($"Qual o nome da música que deseja adicionar ao álbum {nomeDoAlbum}: ");
                string nomeDaMusica = Console.ReadLine()!;
                Console.Write($"Qual a duração da música em minutos: ");
                int duracaoDaMusica = int.Parse(Console.ReadLine()!);
                bandasRegistradas[nomeDaBanda].Albuns.Values.First(a => a.Nome == nomeDoAlbum).AdicionarMusica(new Musica(bandasRegistradas[nomeDaBanda], bandasRegistradas[nomeDaBanda].Albuns.Values.First(a => a.Nome == nomeDoAlbum), nomeDaMusica, duracaoDaMusica));
                Console.WriteLine($"\nA música {nomeDaMusica} foi registrada com sucesso para o álbum {nomeDoAlbum}");
            }
            else
                Console.WriteLine($"\nO álbum {nomeDoAlbum} não foi encontrado!");
        }
        else
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");

        base.Executar(bandasRegistradas);
    }
}
