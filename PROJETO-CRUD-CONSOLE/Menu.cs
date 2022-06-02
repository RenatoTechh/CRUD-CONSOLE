using System;
using System.Collections.Generic;


namespace PROJETO_CRUD_CONSOLE
{
    public static class Menu
    {
        static List<Categoria> listaCategorias = new List<Categoria>();
        static List<Subcategoria> listaSubcategorias = new List<Subcategoria>();

        public static void SelecionaMenu()
        {
            
            while (true)
            {
                Console.WriteLine("Menu Categoria = 1");
                Console.WriteLine("Menu Subcategoria = 2");
                Console.WriteLine("Sair = 0" + Environment.NewLine);

                Console.Write("Escolha a opção desejada: ");
                int opcaoEscolhida = int.Parse(Console.ReadLine());
                Console.WriteLine("-");

                //Chama o menu de Categorias
                if (opcaoEscolhida == 1)
                {
                    PrintarMenuCategoria();
                }
                //Chama o menu de Subcategorias
                else if (opcaoEscolhida == 2)
                {
                    PrintarMenuSubcategoria();
                }
                else if (opcaoEscolhida > 4)
                {
                    Console.WriteLine("-");
                    Console.WriteLine("ESCOLHA UMA DAS OPÇÕES ABAIXO" + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("-");
                    break;
                }
            }
        }
        public static void PrintarMenuCategoria()
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
                    Categoria.AdicionaCategoria(listaCategorias);
 
                }
                //Chama o metodo pesquisar
                else if (opcaoEscolhida == 2)
                {
                    Categoria.PesquisaCategoria(listaCategorias);
                    Console.WriteLine("--------------------");
                }
                //Chama o metodo editar
                else if (opcaoEscolhida == 3)
                {
                    Categoria.EditarCategoria(listaCategorias);
                    Console.WriteLine("--------------------");
                }
                //Chama o metodo excluir
                else if (opcaoEscolhida == 4)
                {
                    Categoria.ExcluirCategoria(listaCategorias);
                }
                else if (opcaoEscolhida > 4)
                {
                    Console.WriteLine("-");
                    Console.WriteLine("ESCOLHA UMA DAS OPÇÕES ABAIXO" + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("-");
                    break;
                }
            }
        }
        public static void PrintarMenuSubcategoria()
        {
            while (true)
            {
                Console.WriteLine("Adicionar = 1");
                Console.WriteLine("Pesquisar = 2");
                Console.WriteLine("Editar = 3");
                Console.WriteLine("Excluir = 4");
                Console.WriteLine("Sair = 0" + Environment.NewLine);
                //Recebe a opção escolhida
                Console.Write("Escolha a opção desejada: ");
                int opcaoEscolhida = int.Parse(Console.ReadLine());

                //Chama o metodo adicionar
                if (opcaoEscolhida == 1)
                {
                    try
                    {
                        Subcategoria.AdicionaSubcategoria(listaSubcategorias);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
                //Chama o metodo pesquisar
                else if (opcaoEscolhida == 2)
                {
                    try
                    {
                        Subcategoria.PesquisaSubcategoria(listaSubcategorias);
                    }
                    catch (ObjetoDaListaNaoEncontradoException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    Console.WriteLine("--------------------");
                }
                //Chama o metodo editar
                else if (opcaoEscolhida == 3)
                {
                    try
                    {
                        Subcategoria.EditarSubcategoria(listaSubcategorias);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                    Console.WriteLine("--------------------");
                }
                //Chama o metodo excluir
                else if (opcaoEscolhida == 4)
                {
                    Subcategoria.ExcluirSubcategoria(listaSubcategorias);
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
