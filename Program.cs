using System;
using System.Collections.Generic;
using System.Linq;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();

        static void Main(string[] args)
        {
           ExercicioAula03();
           //ExemplosListasColecoes();
        }

        public static void ExemplosListasColecoes()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("****** Exemplos - Aula 03 Listas e Coleções ******");
            Console.WriteLine("==================================================");

            CriarLista();
            int opcaoEscolhida = 0;
            do
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("---Digite o número referente a opção desejada: ---");
                Console.WriteLine("1 - Obter Por Id");
                Console.WriteLine("2 - Adicionar Funcionário");
                Console.WriteLine("3 - Obter por Id digitado");
                Console.WriteLine("4 - Obter por Salário digitado");
                Console.WriteLine("==================================================");
                Console.WriteLine("-----Ou tecle qualquer outro número para sair-----");
                Console.WriteLine("==================================================");

                opcaoEscolhida = int.Parse(Console.ReadLine());
                string mensagem = string.Empty;

                switch (opcaoEscolhida)
                {
                    case 1:
                        ObterPorId();
                        break;
                    case 2:
                        AdicionarFuncionario();
                        break;
                    case 3:
                        Console.WriteLine("Digite o Id do funcionário que você deseja buscar:");
                        int id = int.Parse(Console.ReadLine());
                        ObterPorId(id);
                        break;
                    case 4:
                        Console.WriteLine("Digite o salário para obter todos acima do valor indicado:");
                        decimal salario = decimal.Parse(Console.ReadLine());
                        ObterPorSalario(salario);
                        break;
                    default:
                        Console.WriteLine("Saindo do sistema....");
                        break;
                }
            } while (opcaoEscolhida >= 1 && opcaoEscolhida <= 10);

            Console.WriteLine("==================================================");
            Console.WriteLine("* Obrigado por utilizar o sistema e volte sempre *");
            Console.WriteLine("==================================================");
        }

        public static void ExercicioAula03()
        {
            CriarLista();

            Console.WriteLine("====================================================================");
            Console.WriteLine("******************** Exercícios - Aula 03 Listas *******************");
            Console.WriteLine("====================================================================");

            string opcaoEscolhida = "";

            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Observe o menu abaixo e digite a letra referente ao exercício: ");
                Console.WriteLine("a) - Obter por nome");
                Console.WriteLine("b) - Obter funcionários recentes");
                Console.WriteLine("c) - Obter estatísticas");
                Console.WriteLine("d) - Validar salário e data de admissão");
                Console.WriteLine("e) - Validar caracteres do nome");
                Console.WriteLine("f) - Obter por tipo");

                Console.WriteLine("====================================================================");
                Console.WriteLine("---------------Ou tecle qualquer outra letra para sair -------------");
                Console.WriteLine("====================================================================");
                Console.WriteLine("");
                Console.WriteLine("");

                opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida)
                {
                    case "a":
                        ObterPorNome();
                        break;
                    case "b":
                        ObterFuncionariosRecentes();
                        break;
                    case "c":
                        ObterEstatisticas();
                        break;
                    case "d":
                        ValidarSalarioAdmissao();
                        break;
                    case "e":
                        ValidarNome();
                        break;
                    case "f":
                        ObterPorTipo();                        
                        break;
                    default:
                        Console.WriteLine("Saindo do sistema....");
                        break;
                }
            } while (opcaoEscolhida == "a" || opcaoEscolhida == "b" || opcaoEscolhida == "c"
                        || opcaoEscolhida == "d" || opcaoEscolhida == "e" || opcaoEscolhida == "f");

            Console.WriteLine("====================================================================");
            Console.WriteLine("********** Obrigado por utilizar o sistema e volte sempre **********");
            Console.WriteLine("====================================================================");
            Console.WriteLine(""); Console.WriteLine("");
        }

        public static void ValidarNome()
        {

            Funcionario f = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            while (nome.Length < 2)
            {
                Console.WriteLine("O nome deve possuir mais que dois caracteres. Digite novamente.");
                nome = Console.ReadLine();
            }

            f.Nome = nome;

            Console.WriteLine("Digite o salário: ");
            f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            lista.Add(f);
        }


        public static void ValidarSalarioAdmissao()
        {

            bool fAdicionado = false;

            while (fAdicionado == false)
            {
                Funcionario f = new Funcionario();

                Console.WriteLine("Digite o nome: ");
                f.Nome = Console.ReadLine();

                Console.WriteLine("Digite o salário: ");
                f.Salario = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Digite a data de admissão: ");
                f.DataAdmissao = DateTime.Parse(Console.ReadLine());

                if (f.DataAdmissao < DateTime.Now.Date || f.Salario == 0M)
                {
                    Console.WriteLine("A data de admissão não pode ser anterior a hoje e o salário deve ser maior que 0.");
                }
                else
                {
                    fAdicionado = true;
                    lista.Add(f);
                }
            }

        }


        public static void ObterEstatisticas()
        {
            int qtdFuncionarios = lista.Count;
            decimal somatorioSalarios = lista.Sum(x => x.Salario);

            string mensagem = $"Existem {qtdFuncionarios} funcionários com somatório de salários de {somatorioSalarios:c2}";

            Console.WriteLine(mensagem);
        }

        public static void ObterFuncionariosRecentes()
        {
            lista.RemoveAll(x => x.Id < 4);
            lista.OrderByDescending(x => x.Salario);

            ExibirLista();
        }

        public static void ObterPorNome()
        {
            Console.WriteLine("Digite o nome do Funcionário");
            string nome = Console.ReadLine();

            //Opção para nome completo
            //lista = lista.FindAll(x => x.Nome.ToLower() == nome.ToLower());

            //Opção para nome aproximado
            lista = lista.FindAll(x => x.Nome.ToLower().Contains(nome.ToLower()));


            ExibirLista();
        }
        public static void ObterPorTipo()
        {
            Console.WriteLine("Digite 1 para CLT ou 2 para Aprendiz...");
            int tipo = int.Parse(Console.ReadLine());

            TipoFuncionarioEnum tipoConvertidoEnum = (TipoFuncionarioEnum)tipo;
            lista = lista.FindAll(x => x.TipoFuncionario == tipoConvertidoEnum);
            ExibirLista();
        }

        public static void AdicionarFuncionario()
        {
            Funcionario f = new Funcionario();

            Console.WriteLine("Digite o nome: ");
            f.Nome = Console.ReadLine();

            Console.WriteLine("Digite o salário: ");
            f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if (string.IsNullOrEmpty(f.Nome))
            {
                Console.WriteLine("O nome deve ser preenchido");
                return;
            }
            else if (f.Salario == 0)
            {
                Console.WriteLine("Valor do salário não pode ser 0");
                return;
            }      
            else
            {
                lista.Add(f);
                ExibirLista();
            }            
        }

        public static void AdicionarFuncionario2()
        {
            Funcionario f = new Funcionario();
            do
            {
                Console.WriteLine("Digite o nome: ");
                f.Nome = Console.ReadLine();

                Console.WriteLine("Digite o salário: ");
                f.Salario = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Digite a data de admissão: ");
                f.DataAdmissao = DateTime.Parse(Console.ReadLine());
            }
            while (ValidarFuncionario(f) == false);
            ExibirLista();
        }

        public static bool ValidarFuncionario(Funcionario fValidacao)
        {
            if (fValidacao.Salario == 0)
            {
                Console.WriteLine("Valor do salário não pode ser 0");
                return false;
            }
            else if (string.IsNullOrEmpty(fValidacao.Nome))
            {
                Console.WriteLine("O nome deve ser preenchido");
                return false;
            }
            else
            {
                lista.Add(fValidacao);
                return true;
            }
        }

        /*public static bool AdicionarFuncionario(Funcionario fNovo)
        {

            //Opção com While
            /*bool fAdicionado = false;

            while(fAdicionado == false)
            {
                Funcionario f = new Funcionario();            

                Console.WriteLine("Digite o nome: ");
                f.Nome = Console.ReadLine();

                Console.WriteLine("Digite o salário: ");
                f.Salario = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Digite a data de admissão: ");
                f.DataAdmissao = DateTime.Parse(Console.ReadLine());

                fAdicionado = AdicionarFuncionario(f);
            }

            if (fNovo.Salario == 0)
            {
                Console.WriteLine("Valor do salário não pode ser 0");
                return false;
            }
            else
            {
                lista.Add(fNovo);
                return true;
            }
        }*/

        public static void ObterPorSalario(decimal valor)
        {
            lista = lista.FindAll(x => x.Salario >= valor);
            ExibirLista();
        }

        public static void RemoverIdMenor4()
        {
            lista.RemoveAll(x => x.Id < 4);
            ExibirLista();
        }

        public static void ObterPorId(int id)
        {
            Funcionario fBusca = lista.Find(x => x.Id == id);

            Console.WriteLine($"Personagem encontrado: {fBusca.Nome}");
        }

        public static void BuscarPorCpfRemover()
        {
            Funcionario fBusca = lista.Find(x => x.Cpf == "01987654321");
            lista.Remove(fBusca);
            Console.WriteLine($"Personagem removido: {fBusca.Nome} \nLista Atualizada: \n ");

            ExibirLista();
        }

        public static void BuscarPorNomeAproximado()
        {
            AdicionarItem();

            lista = lista.FindAll(x => x.Nome.ToLower().Contains("ronaldo"));

            ExibirLista();
        }

        public static void ExibirAprendizes()
        {
            lista = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
            ExibirLista();
        }

        public static void SomarSalarios()
        {
            decimal somatorio = lista.Sum(x => x.Salario);
            Console.WriteLine(string.Format("A soma dos salários é  {0:c2}.", somatorio));
        }

        public static void ContarFuncionarios()
        {
            int qtd = lista.Count();
            Console.WriteLine($"Existem {qtd} funcionários.");
        }

        public static void Ordenar()
        {
            lista = lista.OrderBy(x => x.Nome).ToList();
            ExibirLista();
        }

        public static void AdicionarItem()
        {

            Funcionario fNovo = new Funcionario();
            fNovo.Id = 9;
            fNovo.Nome = "Ronaldo";
            fNovo.Cpf = "1111111110";
            fNovo.DataAdmissao = DateTime.Parse("17/05/1997");
            fNovo.Salario = 300.000M;
            fNovo.TipoFuncionario = TipoFuncionarioEnum.CLT;

            lista.Add(fNovo);

            ExibirLista();
        }



        public static void ObterPorId()
        {
            lista = lista.FindAll(x => x.Id == 1);
            ExibirLista();
        }

        public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.Cpf = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.Cpf = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.Cpf = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.Cpf = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.Cpf = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnum.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Roger Guedes";
            f6.Cpf = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnum.CLT;
            lista.Add(f6);
        }

        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "===============================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].Cpf);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salário: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "===============================\n";
            }
            Console.WriteLine(dados);
        }





    }
}
