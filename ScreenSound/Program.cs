using ScreenSound.Entidades;

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

        void ExibirLogo()
        {
            Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
            Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
        }

        void ExibirOpcoesDoMenu()
        {
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
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            switch (opcaoEscolhidaNumerica)
            {
                case 1:
                    RegistrarBanda();
                    break;
                case 2:
                    RegistrarAlbum();
                    break;
                case 3:
                    RegistrarUmaMusica();
                    break;
                case 4:
                    MostrarBandasRegistradas();
                    break;
                case 5:
                    AvaliarUmaBanda();
                    break;
                case 6:
                    AvaliarUmAlbum();
                    break;
                case 7:
                    AvaliarUmaMusica();
                    break;
                case 8:
                    ExibirDetalhes();
                    break;
                case -1:
                    Console.WriteLine("Tchau tchau :)");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        void RegistrarAlbum()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Registro de álbuns");
            Console.Write("Digite a banda cujo álbum deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Console.Write("Agora digite o título do álbum: ");
                string tituloAlbum = Console.ReadLine()!;
                Album album = new(tituloAlbum);
                bandasRegistradas[nomeDaBanda].AdicionarAlbum(album);
                Console.WriteLine($"O álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso!");
            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            }
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }

        void RegistrarBanda()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!;
            bandasRegistradas.Add(nomeDaBanda, new Banda(nomeDaBanda));
            Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }

        void MostrarBandasRegistradas()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

            foreach (string banda in bandasRegistradas.Keys)
            {
                Console.WriteLine($"Banda: {banda}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();

        }

        void ExibirTituloDaOpcao(string titulo)
        {
            int quantidadeDeLetras = titulo.Length;
            string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
        }

        void AvaliarUmaBanda()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Avaliar banda");
            Console.Write("Digite o nome da banda que deseja avaliar: ");
            string nomeDaBanda = Console.ReadLine()!;
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Console.Write($"Qual a nota (0 - 10) que a banda {nomeDaBanda} merece: ");
                int nota = int.Parse(Console.ReadLine()!);
                bandasRegistradas[nomeDaBanda].Avaliacao.AdicionarNota(nota);
                Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

        }

        void ExibirDetalhes()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Exibir detalhes da banda");
            Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
            string nomeDaBanda = Console.ReadLine()!;
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Console.WriteLine($"Avaliação: {bandasRegistradas[nomeDaBanda].Media.ToString("F2")}.");
                bandasRegistradas[nomeDaBanda].ExibirDiscografia();
                Console.WriteLine("\n\nDigite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }
        }

        void AvaliarUmAlbum()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Avaliar um álbum");
            Console.Write("Digite o nome da banda: ");
            string nomeDaBanda = Console.ReadLine()!;
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Console.Write("Qual nome do álbum que deseja avaliar: ");
                string nomeDoAlbum = Console.ReadLine()!;
                if (bandasRegistradas[nomeDaBanda].Albuns.ContainsKey(nomeDoAlbum))
                {
                    Console.Write($"Qual a nota (0 - 10) que o álbum {nomeDoAlbum} merece: ");
                    int nota = int.Parse(Console.ReadLine()!);
                    bandasRegistradas[nomeDaBanda].Albuns.Values.First(a => a.Nome == nomeDoAlbum).Avaliacao.AdicionarNota(nota);
                    Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para o álbum {nomeDoAlbum}");
                }
                else
                    Console.WriteLine($"\nO álbum {nomeDoAlbum} não foi encontrado!");
            }
            else
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");

            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }

        void RegistrarUmaMusica()
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

            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }

        void AvaliarUmaMusica()
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

            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }

        ExibirOpcoesDoMenu();
    }
}