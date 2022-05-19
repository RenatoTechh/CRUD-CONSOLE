using System;
using System.Collections.Generic;


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
                Console.WriteLine("Excluir = 4");
                Console.WriteLine("Sair = 0"+ Environment.NewLine);
                //Recebe a opção escolhida
                Console.Write("Escolha a opção desejada: ");
                int opcaoEscolhida = int.Parse(Console.ReadLine());

                //Chama o metodo adicionar
                if (opcaoEscolhida == 1)
                {
                    Categoria.AdicionaCategoria(lista);
                }
                //Chama o metodo pesquisar
                else if (opcaoEscolhida == 2)
                {
                    Categoria.PesquisaCategoria(lista);
                    Console.WriteLine("--------------------");
                }
                //Chama o metodo editar
                else if (opcaoEscolhida == 3)
                {
                    Categoria.EditarCategoria(lista);
                    Console.WriteLine("--------------------");
                }
                //Chama o metodo excluir
                else if (opcaoEscolhida == 4)
                {
                    Categoria.ExcluirCategoria(lista);
                }
                else if (opcaoEscolhida > 4)
                {
                    Console.WriteLine("-");
                    Console.WriteLine("ESCOLHA UMA DAS OPÇÕES ABAIXO" + Environment.NewLine);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
