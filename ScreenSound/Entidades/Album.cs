using ScreenSound.Interfaces;

namespace ScreenSound.Entidades;

internal class Album : IAvaliavel
{
    public static int albunsCriados = 0;
    private List<Musica> musicas = new List<Musica>();
    private Avaliacao avaliacao;

    public Album(string nome)
    {
        Nome = nome;
        if(avaliacao == null)
            avaliacao = new Avaliacao(this);
        albunsCriados++;
    }

    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    public List<Musica> Musicas => musicas;
    public Avaliacao Avaliacao => avaliacao;

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}:\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal}");
    }
}