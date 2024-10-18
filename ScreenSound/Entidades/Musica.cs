namespace ScreenSound.Entidades;

internal class Musica : IAvaliavel
{
    private Avaliacao avaliacao;
    public Musica(Banda artista, Album album, string nome, int duracao)
    {
        Artista = artista;
        Nome = nome;
        Duracao = duracao;
        Album = album;
        if (avaliacao == null)
            avaliacao = new Avaliacao();
    }

    public string Nome { get; }
    public Banda Artista { get; }
    public Album Album { get; }
    public Avaliacao Avaliacao => avaliacao;
    public int Duracao { get; }
    public bool Disponivel { get; set; }
    public string DescricaoResumida => $"A música {Nome} pertence à banda {Artista}.";

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Álbum: {Album.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        } else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }

    public void MudarDisponibilidade(bool disponivel)
    {
        Disponivel = disponivel;
    }
}