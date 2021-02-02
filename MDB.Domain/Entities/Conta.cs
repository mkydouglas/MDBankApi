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
        public double Saldo { get; set; }

        public abstract void Sacar();
    }
}
