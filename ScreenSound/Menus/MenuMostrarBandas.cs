using ScreenSound.Entidades;

namespace ScreenSound.Menus;

internal class MenuMostrarBandas : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");
        Console.WriteLine($"Número total de bandas: {Banda.bandasCriadas}");

        int i = 1;

        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda {i}: {banda}");
            i++;
        }
        base.Executar(bandasRegistradas);
    }
}
