using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PROJETO_CRUD_CONSOLE
{
    public class Subcategoria
    {
        private DateTime _dataNaoModificada;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }

        public Subcategoria(string nome, List<Subcategoria> lista)
        {
            Id = lista.Count;
            if (ValidaNome(nome))
            {
                Nome = nome;
            }
            else
            {
                Console.WriteLine("É PERMITIDO SOMENTE DE 3 - 128 CARACTERES (A-Z) ");
            }
            Nome = nome;
            Status = "Ativo";
            DataCriacao = DateTime.Now;
        }
        public static void AdicionaSubcategoria(List<Subcategoria> lista)
        {
            //Recebe o nome da categoria
            Console.Write("Digite o nome da Subcategoria: ");

            string nome = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome não pode ser nulo ou vazio");
            }
            else
            {
                if (ValidaNome(nome))
                {
                    //Cria um novo objeto
                    var subcategoria = new Subcategoria(nome, lista);

                    //Adiciona a nova categoria na lista
                    lista.Add(subcategoria);
                    Console.WriteLine("-");
                    Console.WriteLine("SUBCATEGORIA CADASTRADA COM SUCESSO" + Environment.NewLine);

                }
                else
                {
                    Console.WriteLine("É PERMITIDO SOMENTE DE 3 - 128 CARACTERES (A-Z) ");
                }
            } 
        }
        public static void PesquisaSubcategoria(List<Subcategoria> lista)
        {
            //Recebe o nome da categoria procurada
            Console.WriteLine("--------------------");
            Console.Write("DIGITE A SUBCATEGORIA PROCURADA: ");
            string subcategoriaEscolhida = Console.ReadLine();
            if (ValidaNome(subcategoriaEscolhida))
            {
                //Verifica se a categoria existe e retorna uma lista com os resultados encontrados
                var listaEncontrados = lista.Where(x => x.Nome.ToLower().Contains(subcategoriaEscolhida.ToLower()));

                //Valida se o valor procurado retorna algum resultado
                if (listaEncontrados.Count() == 0)
                {
                    Console.WriteLine();
                    throw new ObjetoDaListaNaoEncontradoException("Subcategoria não encontrada");
                }
                foreach (var subcategoria in listaEncontrados)
                {
                    Console.WriteLine("-");
                    Console.WriteLine(subcategoria.ToString());
                }
            }
            else
            {
                Console.WriteLine("É PERMITIDO SOMENTE DE 3 - 128 CARACTERES (A-Z) ");
            }
        }

        public static void EditarSubcategoria(List<Subcategoria> lista)
        {
            //Recebe o nome da categoria procurada
            Console.WriteLine("--------------------");
            Console.Write("DIGITE O NOME DA SUBCATEGORIA PARA EDITAR: ");
            string subcategoriaEscolhida = Console.ReadLine();

            //Verifica se a categoria existe e retorna uma lista com os resultados encontrados
            var listaSubcategoriasEncontradas = lista.Where(x => x.Nome.ToLower().Equals(subcategoriaEscolhida.ToLower()));

            if (listaSubcategoriasEncontradas.Count() == 0)
            {
                Console.WriteLine();
                Console.WriteLine("SUBCATEGORIA NÃO ENCONTRADA" + Environment.NewLine);
            }

            foreach (var subcategoria in listaSubcategoriasEncontradas)
            {
                //Exibe a categoria na tela
                Console.WriteLine("-");
                Console.WriteLine(subcategoria.ToString() + Environment.NewLine);

                Console.WriteLine("EDITAR NOME = 1");
                Console.WriteLine("ATIVAR/DESATIVAR SUBCATEGORIA = 2");
                Console.WriteLine("Sair = 0" + Environment.NewLine);

                Console.Write("ESCOLHA A OPÇÃO DESEJADA: ");
                var opcaoEscolhida = int.Parse(Console.ReadLine());

                switch (opcaoEscolhida)
                {
                    case 1:
                        Console.Write("DIGITE UM NOVO NOME PARA A SUBCATEGORIA: ");
                        string subcategoriaNovoNome = Console.ReadLine();

                        if (String.IsNullOrWhiteSpace(subcategoriaNovoNome))
                        {
                            throw new ArgumentException("Nome não pode ser nulo ou vazio");
                        }
                        else
                        {
                            if (ValidaNome(subcategoriaNovoNome))
                            {
                                subcategoria.Nome = subcategoriaNovoNome;
                                Console.Write("NOVO NOME DA SUBCATEGORIA EDITADO COM SUCESSO, AGORA ELA SE CHAMA: " + subcategoria.Nome + Environment.NewLine);
                                subcategoria.DataModificacao = DateTime.Now;
                            }
                            else
                            {
                                Console.WriteLine("É PERMITIDO SOMENTE DE 3 - 128 CARACTERES (A-Z) ");
                            }
                        }
                        break;
                    case 2:
                        Console.Write("Deseja desativar a subcategoria? (Y/N): ");
                        var opcao = Console.ReadLine();
                        if (opcao.ToLower() == "y")
                        {
                            subcategoria.Status = "Inativo";
                            Console.WriteLine();
                            Console.WriteLine("SUBCATEGORIA DESATIVADA");
                            subcategoria.DataModificacao = DateTime.Now;
                        }
                        else if(opcao.ToLower() == "y")
                        {
                            Console.WriteLine("Status = Ativo");
                        }
                        else
                        {
                            Console.WriteLine("Digite uma opção válida.");
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("DIGITE UMA OPÇÃO VÁLIDA");
                        break;
                }

                Console.WriteLine("-");
            }
        }
        public static void ExcluirSubcategoria(List<Subcategoria> lista)
        {
            //Recebe o nome da categoria procurada
            Console.WriteLine("--------------------");
            Console.Write("DIGITE O NOME DA SUBCATEGORIA QUE DESEJA EXCLUIR: ");
            string subcategoriaEscolhida = Console.ReadLine();

            //Verifica se a categoria existe e retorna uma lista com os resultados encontrados
            var listaCategoriasEncontradas = lista.Where(x => x.Nome.ToLower().Equals(subcategoriaEscolhida.ToLower()));

            if (listaCategoriasEncontradas.Count() == 0)
            {
                Console.WriteLine();
                Console.WriteLine("SUBCATEGORIA NÃO ENCONTRADA" + Environment.NewLine);
            }
            else
            {
                lista.RemoveAll((x) => x.Nome.ToLower() == subcategoriaEscolhida.ToLower());
                Console.WriteLine("-");
                Console.WriteLine("SUBCATEGORIA EXCLUÍDA COM SUCESSO" + Environment.NewLine);
            }
        }
        public static bool ValidaNome(string nome)
        {
            if (nome.Length >= 3 && Regex.IsMatch(nome, "^[a-zA-Z' ']+$") && nome.Length <= 128)
            {
                return true;
            }
                return false;
        }             
        public override string ToString()
        {
            if (DataModificacao == _dataNaoModificada)
            {
                return "ID: " + Id + "\n" + "NOME DA SUBCATEGORIA: " + Nome + "\n" + "STATUS: " + Status + "\n" + "DATA DE CRIAÇÃO: " + DataCriacao;
            }
            else
            {
                return "ID: " + Id + "\n" + "NOME DA SUBCATEGORIA: " + Nome + "\n" + "STATUS: " + Status + "\n" + "DATA DE CRIAÇÃO: " + DataCriacao + "\n" + "DATA DA MODIFICAÇÃO: " + DataModificacao;
            }

        }
    }
}
