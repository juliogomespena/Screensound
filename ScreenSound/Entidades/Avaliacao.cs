namespace ScreenSound.Entidades;

internal class Avaliacao
{
    public Avaliacao()
    {
        if (Notas == null)
            Notas = new List<int>();
    }

    private List<int> Notas { get; }
    public double Media
    {
        get
        {
            if (NotasCount == 0)
                return 0;
            else
                return Notas.Average();
        }
    }
    public int NotasCount => Notas.Count();

    public void AdicionarNota(int nota)
    {
        if(nota < 0 || nota > 10)
        {
            Console.WriteLine("Nota inválida. A nota deve ser entre 0 e 10.");
        }
        else
            Notas.Add(nota);
        return;
    }
    public void ExibirNotas()
    {
        Console.WriteLine($"\nNotas: {string.Join(" - ", Notas)}");

    }
}
