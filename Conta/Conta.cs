using System;

namespace banco
{
    public class Conta
    {
        private string Nome {get; set;}

        private double Credito {get; set;}

        private double Saldo {get; set;}

        private TipoConta TipoConta {get; set;} //enum

        public Conta(string Nome, double Credito, double Saldo, TipoConta TipoConta){
            this.Nome = Nome;
            this.Credito = Credito;
            this.Saldo = Saldo;
            this.TipoConta = TipoConta;
        }

        public bool Sacar(double valorSaque){
            //Validar saldo
            if(this.Saldo - valorSaque < Credito){
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}",this.Nome,this.Saldo);
            return true;
        }

        public void Depositar(double ValorDeposito){
            this.Saldo += ValorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}",this.Nome,this.Saldo);
        }

        public void Transferir(double ValorTransferencia, Conta ContaDestino){
            if(this.Sacar(ValorTransferencia)){
                ContaDestino.Depositar(ValorTransferencia);
            }
        }

        public override string ToString(){ //Sobrescrevendo método ToString de Object
            string retorno = "";
            retorno += "Tipo de conta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}