using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Categoria(string nome, List<Categoria> lista)
        {
            Id = lista.Count;
            if (nome.Length <= 128)
            {
                Nome = nome;
            }
            else
            {
                Console.WriteLine("Máximo de 128 caractéres");
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
            //Cria um novo objeto
            var categoria = new Categoria(nome, lista);
            //Adiciona a nova categoria na lista
            lista.Add(categoria);
            Console.WriteLine();
        }
        public static void PesquisaCategoria(List<Categoria> lista)
        {
            //Recebe o nome da categoria procurada
            Console.WriteLine("--------------------");
            Console.Write("DIGITE A CATEGORIA PROCURADA: ");
            string categoriaEscolhida = Console.ReadLine();

            //Verifica se a categoria existe e retorna uma lista com os resultados encontrados
            var listaEncontrados = lista.Where(x => x.Nome.ToLower().Contains(categoriaEscolhida.ToLower()));

            //Valida se o valor procurado retorna algum resultado
            if (listaEncontrados.Count() == 0)
            {
                Console.WriteLine("Categoria não encontrada");
            }
            foreach (var item in listaEncontrados)
            {
                Console.WriteLine("-");
                Console.WriteLine(item.ToString());
            }
        }

        public override string ToString()
        {
            if (DataModificacao == _dataNaoModificada)
            {
                return "ID: " + Id + "\n" + "NOME DA CATEGORIA: " + Nome + "\n" + "STATUS: " + Status + "\n" + "DATA DE CRIAÇÃO: " + DataCriacao;
            }
            else
            {
                return "ID: " + Id + "\n" + "NOME DA CATEGORIA: " + Nome + "\n" + "STATUS: " + Status + "\n" + "DATA DE CRIAÇÃO: " + DataCriacao + "\n" + "DATA DA MODIFICAÇÃO: " + DataModificacao;
            }

        }
    }
}
