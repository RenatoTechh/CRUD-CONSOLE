using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PROJETO_CRUD_CONSOLE
{
    public static class Menu
    {
        static List<Categoria> lista = new List<Categoria>();
        public static void PrintarMenu()
        {
            while (true)
            {
                Console.WriteLine("Adicionar = 1");
                Console.WriteLine("Pesquisar = 2");
                Console.WriteLine("Editar = 3");
                Console.WriteLine("Sair = 0");

                Console.WriteLine("Escolha a opção desejada: ");
                int opcaoEscolhida = int.Parse(Console.ReadLine());


                if (opcaoEscolhida == 1)
                {
                    Categoria.AdicionaCategoria(lista);
                }
                else if (opcaoEscolhida == 2)
                {
                    Categoria.PesquisaCategoria(lista);
                    Console.WriteLine("--------------------");
                }
                else if (opcaoEscolhida == 3)
                {
                    //editar
                }
                else
                {
                    break;
                }
            }
        }
    }
}
