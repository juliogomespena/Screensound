using ScreenSound.Interfaces;

namespace ScreenSound.Entidades;

internal class Banda : IAvaliavel
{
    public static int bandasCriadas = 0;
    private Dictionary<string, Album> albuns = new Dictionary<string, Album>();
    private Avaliacao avaliacao;

    public Banda(string nome)
    {
        Nome = nome;
        if(avaliacao == null)
            avaliacao = new Avaliacao(this);
        bandasCriadas++;
    }

    public string Nome { get; }
    public double Media => avaliacao.Media;
    public Dictionary<string, Album> Albuns => albuns;
    public Avaliacao Avaliacao => avaliacao;

    public void AdicionarAlbum(Album album) 
    { 
        albuns.Add(album.Nome, album);
    }

    public void ExibirDiscografia()
    {
        if (albuns.Count == 0)
        {
            Console.WriteLine("Esta banda não possui álbuns.");
        }
        else
        {
            Console.WriteLine($"\nDiscografia ->");
            int j = 1;
            foreach (var album in albuns.Values)
            {
                Console.WriteLine($"    Álbum {j}: {album.Nome} - Avaliação: {album.Avaliacao.Media} - Duração: {album.DuracaoTotal}");
                if (album.Musicas.Count == 0)
                {
                    Console.WriteLine("         Este álbum não possui músicas.");
                }
                else
                {
                    int i = 1;
                    foreach (var musica in album.Musicas)
                    {
                        Console.WriteLine($"        Música {i}: {musica.Nome} - Avaliação: {musica.Avaliacao.Media} - Duração: {musica.Duracao}");
                        i++;
                    }
                }
                j++;
            }
        }
    }
}