using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario){
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizaSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        ListarFilme();
                        break;
                    case "7":
                        InserirFilme();
                        break;
                    case "8":
                        AtualizaFilme();
                        break;
                    case "9":
                        ExcluirFilme();
                        break;
                    case "10":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSerie(){
            Console.WriteLine("Listar série");
            var lista = repositorioSerie.Lista();

            if (lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var Serie in lista){
                var excluido = Serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}",Serie.retornId(),Serie.retornaTitulo(), (excluido ? "*Excluido*":""));
            }

        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} = {1} ", i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Seríe: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioSerie.Insere(novaSerie);
        }
        private static void AtualizaSerie(){
            Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} = {1} ", i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Seríe: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioSerie.Atualiza(indiceSerie,atualizaSerie);
        }
        private static void ExcluirSerie(){
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorioSerie.Exclui(indiceSerie);
        }
        private static void VisualizarSerie(){
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
           private static void ListarFilme(){
            Console.WriteLine("Listar filme");
            var lista = repositorioFilme.Lista();

            if (lista.Count == 0){
                Console.WriteLine("Nenhum filme cadastrada.");
                return;
            }

            foreach(var Filme in lista){
                var excluido = Filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}",Filme.retornId(),Filme.retornaTitulo(), (excluido ? "*Excluido*":""));
            }

        }
        
        private static void InserirFilme(){
            Console.WriteLine("Inserir novo filme");

            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} = {1} ", i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição ao Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioFilme.Insere(novoFilme);
        }
         private static void AtualizaFilme(){
            Console.WriteLine("Digite o id do filme");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} = {1} ", i,Enum.GetName(typeof(Genero),i));
            }
            Console.Write("Digite o gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorioFilme.Atualiza(indiceFilme,atualizaFilme);
        }
        private static void ExcluirFilme(){
            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorioFilme.Exclui(indiceFilme);
        }
        private static void VisualizarFilme(){
            Console.Write("Digite o id do filme: ");
            int indicefilme = int.Parse(Console.ReadLine());

            var Filme = repositorioFilme.RetornaPorId(indicefilme);

            Console.WriteLine(Filme);
        }
           private static void ListaFilme(){
            Console.WriteLine("Listar filme");
            var lista = repositorioFilme.Lista();

            if (lista.Count == 0){
                Console.WriteLine("Nenhum filme cadastrada.");
                return;
            }

            foreach(var Filme in lista){
                var excluido = Filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}",Filme.retornId(),Filme.retornaTitulo(), (excluido ? "*Excluido*":""));
            }

        }
        private static string ObterOpcaoUsuario(){
            
            Console.WriteLine();
            Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar Serie");
            Console.WriteLine("6- Listar Filme");
            Console.WriteLine("7- Inserir novo Filme");
            Console.WriteLine("8- Atualizar Filme");
            Console.WriteLine("9- Excluir Filme");
            Console.WriteLine("10- Visualizar Filme");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
