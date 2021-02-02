using System;
using System.Collections.Generic;
using System.Text;

namespace MDB.Domain.Entities
{
    public class ContaPoupanca : Conta
    {
        public ContaPoupanca(string titular, int agencia, int numero, double saldo) : base(titular, agencia, numero, saldo)
        {

        }

        public override void Depositar(double valor)
        {
            Saldo += valor;
        }

        public override bool Sacar(double valor)
        {
            if (valor > Saldo)
            {
                return false;
            }

            Saldo -= valor;
            return true;
        }

        public override bool Transferir(double valor, Conta contaDestino)
        {
            bool retorno = Sacar(valor);
            if (!retorno)
            {
                return false;
            }

            contaDestino.Depositar(valor);
            return true;
        }
    }
}
