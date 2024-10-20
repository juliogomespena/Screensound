using ScreenSound.Entidades;
using ScreenSound.Menus;

internal class Program
{
    private static void Main(string[] args)
    {

        Banda banda01 = new("Linkin Park");
        Banda banda02 = new("The Beatles");

        banda01.Avaliacao.AdicionarNota(10);
        banda01.Avaliacao.AdicionarNota(8);
        banda01.Avaliacao.AdicionarNota(6);
        banda02.Avaliacao.AdicionarNota(9);
        banda02.Avaliacao.AdicionarNota(7);
        banda02.Avaliacao.AdicionarNota(9);
        banda02.AdicionarAlbum(new Album("Abbey Road"));

        Dictionary<string, Banda> bandasRegistradas = new Dictionary<string, Banda>();

        bandasRegistradas.Add(banda01.Nome, banda01);
        bandasRegistradas.Add(banda02.Nome, banda02);

        Menu menu = new MenuExibirOpcoes();
        menu.Executar(bandasRegistradas);

    }
}