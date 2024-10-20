using ScreenSound.Entidades;

namespace ScreenSound.Menus;

internal class MenuExibirOpcoes : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Dictionary<string, Menu> opcoes = new();

        opcoes.Add("1", new MenuRegistrarBanda());
        opcoes.Add("2", new MenuRegistrarAlbum());
        opcoes.Add("3", new MenuRegistrarMusica());
        opcoes.Add("4", new MenuMostrarBandas());
        opcoes.Add("5", new MenuAvaliarBanda());
        opcoes.Add("6", new MenuAvaliarAlbum());
        opcoes.Add("7", new MenuAvaliarMusica());
        opcoes.Add("8", new MenuExibirDetalhes());
        opcoes.Add("-1", new MenuSair());

        ExibirLogo();
        Console.WriteLine("\nDigite 1 para registrar uma banda");
        Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
        Console.WriteLine("Digite 3 para registrar música a um álbum");
        Console.WriteLine("Digite 4 para mostrar todas as bandas");
        Console.WriteLine("Digite 5 para avaliar uma banda");
        Console.WriteLine("Digite 6 para avaliar um albúm");
        Console.WriteLine("Digite 7 para avaliar uma música");
        Console.WriteLine("Digite 8 para exibir os detalhes de uma banda");
        Console.WriteLine("Digite -1 para sair");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;

        if(!opcoes.ContainsKey(opcaoEscolhida))
        {
            Console.WriteLine("Opção inválida!");
            Thread.Sleep(600);
            Console.Clear();
        }
        else
        {
            Menu menu = opcoes[opcaoEscolhida];
            menu.Executar(bandasRegistradas);
        }
        Executar(bandasRegistradas);
    }
}
