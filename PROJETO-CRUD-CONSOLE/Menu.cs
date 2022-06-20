using System;
using System.Collections.Generic;
using System.Linq;

namespace PROJETO_CRUD_CONSOLE
{
    public static class Menu
    {
        public static List<Categoria> listaCategorias = new List<Categoria>();



        public static void SelecionaMenu()
        {

            while (true)
            {
                Console.WriteLine("Menu Categoria = 1");
                Console.WriteLine("Menu Subcategoria = 2");
                Console.WriteLine("Menu Produto = 3");
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
                //Chama o menu do Produto
                else if (opcaoEscolhida == 3)
                {
                    PrintarMenuProduto();
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
                Console.WriteLine("Cadastrar = 1");
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
                    Categoria.AdicionaCategoria(listaCategorias);
                    Console.WriteLine("--------------------");
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
        public static void PrintarMenuProduto()
        {
            while (true)
            {

                Console.WriteLine("Cadastrar = 1");
                Console.WriteLine("Pesquisar = 2");
                Console.WriteLine("Editar = 3");
                Console.WriteLine("Excluir = 4");
                Console.WriteLine("Sair = 0" + Environment.NewLine);
                //Recebe a opção escolhida
                Console.Write("Escolha a opção desejada: ");
                int opcaoEscolhida = int.Parse(Console.ReadLine());

                if (opcaoEscolhida == 1)
                {
                    try
                    {
                        Console.Write("Digite o nome da Subcategoria para cadastrar o produto: ");
                        var subcategoriaNome = Console.ReadLine();

                        foreach (var categoria in listaCategorias)
                        {
                            foreach (var subcategoria in categoria.Subcategorias)
                            {
                                if (subcategoria.Nome.ToLower() == subcategoriaNome.ToLower())
                                {
                                    Console.WriteLine("Digite os dados abaixo para cadastrar o produto: ");
                                    Console.Write("Nome: ");
                                    var nome = Console.ReadLine();
                                    Console.Write("Descrição: ");
                                    var descricao = Console.ReadLine();
                                    Console.Write("Peso(kg): ");
                                    var peso = double.Parse(Console.ReadLine());
                                    Console.Write("Altura(m): ");
                                    var altura = double.Parse(Console.ReadLine());
                                    Console.Write("Largura(m): ");
                                    var largura = double.Parse(Console.ReadLine());
                                    Console.Write("Comprimento(m): ");
                                    var comprimento = double.Parse(Console.ReadLine());
                                    Console.Write("Valor(R$): ");
                                    var valor = double.Parse(Console.ReadLine());
                                    Console.Write("Quantidade: ");
                                    var quantidade = int.Parse(Console.ReadLine());
                                    Console.Write("Centro de distribuição: ");
                                    var centroDeDistribuicao = Console.ReadLine();

                                    Produto.Cadastrar(nome, descricao, peso, altura, largura, comprimento, valor, quantidade, centroDeDistribuicao, Subcategoria.listaProdutos); ;
                                }
                            }
                        }
                    }
                    catch (ArgumentNullException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //Pesquisa produto
                else if (opcaoEscolhida == 2)
                {
                    Produto.PesquisaProduto(Subcategoria.listaProdutos);  
                }
                //Edita o status do produto
                else if (opcaoEscolhida == 3)
                {
                    Produto.EditarProduto(Subcategoria.listaProdutos);
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
                        Console.Write("Digite o nome da categoria que deseja cadastrar a subcategoria: ");
                        var categoriaNome = Console.ReadLine();

                        //Verifica se a categoria existe e retorna uma lista com os resultados encontrados
                        var listaEncontrados = listaCategorias.Where(x => x.Nome.ToLower().Equals(categoriaNome.ToLower()));

                        //Valida se o valor procurado retorna algum resultado
                        if (listaEncontrados.Count() == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Categoria não encontrada");
                        }
                        foreach (var categoria in listaEncontrados)
                        {
                            Console.WriteLine("-");
                            Subcategoria.AdicionaSubcategoria(categoria.Subcategorias);
                        }
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
                        foreach (var categoria in listaCategorias)
                        {
                            Subcategoria.PesquisaSubcategoria(categoria.Subcategorias);
                        }

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
                        foreach (var categoria in listaCategorias)
                        {
                            Subcategoria.EditarSubcategoria(categoria.Subcategorias);
                        }
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
                    foreach (var categoria in listaCategorias)
                    {
                        Subcategoria.ExcluirSubcategoria(categoria.Subcategorias);
                    }
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
