using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PROJETO_CRUD_CONSOLE
{
    public class Categoria
    {
        private DateTime _dataNaoModificada;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }

        public List<Subcategoria> Subcategorias = new List<Subcategoria>();

        public Categoria(string nome, List<Categoria> lista)
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
        public static void AdicionaCategoria(List<Categoria> lista)
        {
            //Recebe o nome da categoria
            Console.Write("Digite o nome da Categoria: ");
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
                    var categoria = new Categoria(nome, lista);

                    //Adiciona a nova categoria na lista
                    lista.Add(categoria);
                    Console.WriteLine("-");
                    Console.WriteLine("CATEGORIA CADASTRADA COM SUCESSO" + Environment.NewLine);

                }
                else
                {
                    Console.WriteLine("É PERMITIDO SOMENTE DE 3 - 128 CARACTERES (A-Z) ");
                }
            }
        }
        public static void PesquisaCategoria(List<Categoria> lista)
        {
            //Recebe o nome da categoria procurada
            Console.WriteLine("--------------------");
            Console.Write("DIGITE A CATEGORIA PROCURADA: ");
            string categoriaEscolhida = Console.ReadLine();
            if (ValidaNome(categoriaEscolhida))
            {
                //Verifica se a categoria existe e retorna uma lista com os resultados encontrados
                var listaEncontrados = lista.Where(x => x.Nome.ToLower().Contains(categoriaEscolhida.ToLower()));

                //Valida se o valor procurado retorna algum resultado
                if (listaEncontrados.Count() == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Categoria não encontrada" + Environment.NewLine);
                }
                foreach (var categoria in listaEncontrados)
                {
                    Console.WriteLine("-");
                    Console.WriteLine(categoria.ToString());
                    foreach (var subcategoria in categoria.Subcategorias)
                    {
                        Console.WriteLine(subcategoria.ToString()); 
                    }
                }
            }
            else
            {
                Console.WriteLine("É PERMITIDO SOMENTE DE 3 - 128 CARACTERES (A-Z) ");
            }
        }

        public static void EditarCategoria(List<Categoria> lista)
        {
            //Recebe o nome da categoria procurada
            Console.WriteLine("--------------------");
            Console.Write("DIGITE O NOME DA CATEGORIA PARA EDITAR: ");
            string categoriaEscolhida = Console.ReadLine();

            //Verifica se a categoria existe e retorna uma lista com os resultados encontrados
            var listaCategoriasEncontradas = lista.Where(x => x.Nome.ToLower().Equals(categoriaEscolhida.ToLower()));

            if (listaCategoriasEncontradas.Count() == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Categoria não encontrada" + Environment.NewLine);
            }

            foreach (var categoria in listaCategoriasEncontradas)
            {
                //Exibe a categoria na tela
                Console.WriteLine("-");
                Console.WriteLine(categoria.ToString() + Environment.NewLine);

                Console.Write("DIGITE UM NOVO NOME PARA A CATEGORIA: ");
                string categoriaNovoNome = Console.ReadLine();

                categoria.Nome = categoriaNovoNome;
                categoria.DataModificacao = DateTime.Now;
                Console.WriteLine("-");
                Console.Write("NOVO NOME DA CATEGORIA EDITADO COM SUCESSO, AGORA ELA SE CHAMA: " + categoria.Nome + Environment.NewLine);

            }
        }
        public static void ExcluirCategoria(List<Categoria> lista)
        {
            //Recebe o nome da categoria procurada
            Console.WriteLine("--------------------");
            Console.Write("DIGITE O NOME DA CATEGORIA QUE DESEJA EXCLUIR: ");
            string categoriaEscolhida = Console.ReadLine();

            //Verifica se a categoria existe e retorna uma lista com os resultados encontrados
            var listaCategoriasEncontradas = lista.Where(x => x.Nome.ToLower().Equals(categoriaEscolhida.ToLower()));

            if (listaCategoriasEncontradas.Count() == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Categoria não encontrada" + Environment.NewLine);
            }
            else
            {
                lista.RemoveAll((x) => x.Nome.ToLower() == categoriaEscolhida.ToLower());
                Console.WriteLine("-");
                Console.WriteLine("CATEGORIA EXCLUÍDA COM SUCESSO" + Environment.NewLine);
            }
        }
        public static bool ValidaNome(string nome)
        {
            if (nome.Length >= 3 && Regex.IsMatch(nome, "^[a-zA-Z' ']+$") && nome.Length <= 128)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            if (DataModificacao == _dataNaoModificada)
            {
                
                return "ID: " + Id + "\n" + "NOME DA CATEGORIA: " + Nome + "\n" + "STATUS: " + Status + "\n" + "DATA DE CRIAÇÃO: " + DataCriacao;
            }
            return "ID: " + Id + "\n" + "NOME DA CATEGORIA: " + Nome + "\n" + "STATUS: " + Status + "\n" + "DATA DE CRIAÇÃO: " + DataCriacao + "\n" + "DATA DA MODIFICAÇÃO: " + DataModificacao;

        }
    }
}
