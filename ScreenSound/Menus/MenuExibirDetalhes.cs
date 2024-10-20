using ScreenSound.Entidades;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhes : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Exibir detalhes da banda");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"Avaliação: {bandasRegistradas[nomeDaBanda].Media.ToString("F2")}.");
            bandasRegistradas[nomeDaBanda].ExibirDiscografia();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");

        }
        base.Executar(bandasRegistradas);
    }
}
