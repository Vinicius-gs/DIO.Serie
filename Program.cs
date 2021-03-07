using System;
using DIO.Sertes.Classes;

namespace DIO.Sertes
{
    class Program
    {
        static SerieRepositorio repositorio =  new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario =  ObeterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                case "1":
                    ListarSerie();
                    break;

                case "2":
                    InserirSerie();
                    break;

                case "3":
                    AtualizarSerie();
                    break;

                case "4":
                    ExluirSerie();
                    break; 

                case "5":
                    VisualizarSerie();
                    break;   

                case "C":
                    Console.Clear();
                    break;   

                   default:
                    throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario =  ObeterOpcaoUsuario();
           }
           
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontra");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} - {2}",serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Series");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i , Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie:");
            string entradaTitulo= Console.ReadLine();

            Console.WriteLine("Digite o Ano  do inicio da Serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaserie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo : entradaTitulo, ano : entradaAno, descricao: entradaDescricao);

            repositorio.Inserir(novaserie);

        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da Serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i , Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie:");
            string entradaTitulo= Console.ReadLine();

            Console.WriteLine("Digite o Ano  do inicio da Serie");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie , genero: (Genero)entradaGenero, titulo : entradaTitulo, ano : entradaAno, descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie , atualizarSerie);

        }

        private static void ExluirSerie()
        {
            Console.WriteLine("Digite o ID da Serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static string ObeterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Serie a seu dispor");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar Serie");
            Console.WriteLine("2 - Inserir nova Serie");
            Console.WriteLine("3 - Atualizar Serie");
            Console.WriteLine("4 - Exluir Serie");
            Console.WriteLine("5 - Visualizar Serie");
            Console.WriteLine("C - Limpar Tela"); 
            Console.WriteLine("X - Sair");      
            Console.WriteLine();


            String opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
