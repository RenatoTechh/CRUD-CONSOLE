using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_CRUD_CONSOLE
{
    public class Produto
    {
        private DateTime _dataNaoModificada;
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Peso { get; private set; }
        public double Altura { get; private set; }
        public double Largura { get; private set; }
        public double Comprimento { get; private set; }
        public double Valor { get; private set; }
        public int Quantidade { get; private set; }
        public string CentroDistribuicao { get; private set; }
        public string Status { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataModificacao { get; private set; }

        public static void Cadastrar(string nome, string descricao, double peso, double altura, double largura, double comprimento, double valor, int quantidade, string centroDistribuicao, List<Produto> lista)
        {
            if (ValidaProduto(nome,descricao))
            {
                var produto = new Produto();

                produto.Nome = nome;
                produto.Descricao = descricao;
                produto.Peso = peso;
                produto.Altura = altura;
                produto.Largura = largura;
                produto.Comprimento = comprimento;
                produto.Valor = valor;
                produto.Quantidade = quantidade;
                produto.CentroDistribuicao = centroDistribuicao;
                produto.Status = "Ativo";
                produto.DataCriacao = DateTime.Now;

                Console.WriteLine("-");

                lista.Add(produto);

            }
            
        }
        public static void PesquisaProduto(List<Produto> lista)
        {
            //Recebe o nome da categoria procurada
            Console.WriteLine("--------------------");
            Console.Write("DIGITE O NOME DO PRODUTO PROCURADO: ");
            string produtoEscolhido = Console.ReadLine();

            if (produtoEscolhido.Length >= 3 && produtoEscolhido.Length <= 128)
            {
                //Verifica se o produto existe e retorna uma lista com os resultados encontrados
                var listaEncontrados = lista.Where(x => x.Nome.ToLower().Contains(produtoEscolhido.ToLower()));

                //Valida se o valor procurado retorna algum resultado
                if (listaEncontrados.Count() == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Produto não encontrado" + Environment.NewLine);
                }
                foreach (var categoria in Menu.listaCategorias)
                {
                    foreach (var subcategoria in categoria.Subcategorias)
                    {
                        foreach (var produto in Subcategoria.listaProdutos)
                        {
                            if(produto.Nome.ToLower() == produtoEscolhido.ToLower())
                            {
                                Console.WriteLine("-");
                                Console.WriteLine(categoria.ToString() + Environment.NewLine);
                                Console.WriteLine(subcategoria.ToString() + Environment.NewLine);
                                Console.WriteLine(produto.ToString() + Environment.NewLine);
                                Console.WriteLine("-");

                            }
                        }
                        
                    }
                }
            }
            else
            {
                Console.WriteLine("É PERMITIDO SOMENTE DE 3 - 128 CARACTERES (A-Z) ");
            }
        }
        public static void EditarProduto(List<Produto> lista)
        {
            //Recebe o nome da categoria procurada
            Console.WriteLine("--------------------");
            Console.Write("DIGITE O NOME DO PRODUTO PARA EDITAR: ");
            string produtoEscolhido = Console.ReadLine();

            //Verifica se a categoria existe e retorna uma lista com os resultados encontrados
            var listaEncontrados = lista.Where(x => x.Nome.ToLower().Equals(produtoEscolhido.ToLower()));

            if (listaEncontrados.Count() == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Produto não encontrado" + Environment.NewLine);
            }

            foreach (var produto in listaEncontrados)
            {
                //Exibe a categoria na tela
                Console.WriteLine("-");
                Console.WriteLine(produto.ToString() + Environment.NewLine);

                Console.WriteLine("Ativar produto = 1");
                Console.WriteLine("Desativar produto = 2");
                Console.Write("Escolha uma das opções acima: ");

                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        produto.Status = "Ativo";
                        produto.DataModificacao = DateTime.Now;
                        Console.WriteLine("Status alterado com sucesso." + Environment.NewLine);
                        break;
                    case 2:
                        produto.Status = "Inativo";
                        produto.DataModificacao = DateTime.Now;
                        Console.WriteLine("Status alterado com sucesso." + Environment.NewLine);
                        break;
                    default:
                        Console.WriteLine("Escolha uma opção válida.");
                        break;
                }

            }
        }
        public static bool ValidaProduto(string nome, string descricao)
        {
            var minNome = 3;
            var maxNome = 128;
            var maxDescricao = 512;
            if (nome.Length <= maxNome && descricao.Length <= maxDescricao && nome.Length >= minNome)
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

                return
                    "Nome: " + Nome +
                    "\n" + "Descrição: " + Descricao +
                    "\n" + "Peso(kg): " + Peso +
                    "\n" + "Altura(m): " + Altura +
                    "\n" + "Largura(m): " + Largura +
                    "\n" + "Comprimento(m): " + Comprimento +
                    "\n" + "Valor(R$): " + Valor +
                    "\n" + "Quantidade: " + Quantidade +
                    "\n" + "Centro de Distribuição: " + Largura +
                    "\n" + "Status: " + Status +
                    "\n" + "Data de Criação: " + DataCriacao;
            }
            return
                "Nome: " + Nome +
                    "\n" + "Descrição: " + Descricao +
                    "\n" + "Peso(kg): " + Peso +
                    "\n" + "Altura(m): " + Altura +
                    "\n" + "Largura(m): " + Largura +
                    "\n" + "Comprimento(m): " + Comprimento +
                    "\n" + "Valor(R$): " + Valor +
                    "\n" + "Quantidade: " + Quantidade +
                    "\n" + "Centro de Distribuição: " + Largura +
                    "\n" + "Status: " + Status +
                    "\n" + "Data de Criação: " + DataCriacao +
                    "\n" + "Data da Modificação: " + DataModificacao;
        }
    }
}
