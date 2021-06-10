using System;
using System.Collections.Generic;

namespace banco
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterUsuario();

            while(opcaoUsuario.ToUpper()!="0"){
                switch(opcaoUsuario){
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Console.Clear(); //Limpa a tela
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterUsuario();
            }
        }

        private static string ObterUsuario(){
            Console.WriteLine("");
            Console.WriteLine("Aguardando comando...");
            Console.WriteLine("1 - listar contas");
            Console.WriteLine("2 - nova conta");
            Console.WriteLine("3 - transferir");
            Console.WriteLine("4 - sacar");
            Console.WriteLine("5 - depositar");
            Console.WriteLine("6 - limpar tela");
            Console.WriteLine("0 - sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarContas(){
            Console.WriteLine("Listar Contas");
            
            if(listaContas.Count==0){
                Console.WriteLine("Nenhuma informação pra mostrar.");
                return;
            }

            for(int i=0; i<listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.WriteLine("#{0} - ",i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta(){
            Console.WriteLine("Nova Conta");
            Console.WriteLine("1-Pessoa Física || 2-Pessoa Jurídica :");

            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Valor do saldo: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(entradaNome,
                            entradaCredito,
                            entradaSaldo,
                            (TipoConta)entradaTipoConta);

            listaContas.Add(novaConta);
            return;
        }

        private static void Sacar(){
            Console.Write("Digite o Número da conta: ");
            int indice = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indice].Sacar(valorSaque);
        }

        private static void Depositar(){
            Console.Write("Digite o Número da conta: ");
            int indice = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indice].Depositar(valorDeposito);
        }

        private static void Transferir(){
            Console.Write("Digite o Número da conta origem: ");
            int indiceOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o Número da conta destino: ");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            bool validar = listaContas[indiceOrigem].Sacar(valorTransferencia);

            if(validar){
                listaContas[indiceDestino].Depositar(valorTransferencia);
            }
        }
    }
}
