using System;
using System.Collections.Generic;
using System.Text;

namespace MDB.Domain.Entities
{
    public abstract class Conta
    {
        public string Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public double Saldo { get; protected set; }

        protected Conta(string titular, int agencia, int numero, double saldo)
        {
            Titular = titular;
            Agencia = agencia;
            Numero = numero;
            Saldo = saldo;
        }

        public abstract void Depositar(double valor);
        public abstract bool Sacar(double valor);
        public abstract bool Transferir(double valor, Conta contaDestino);
    }
}
