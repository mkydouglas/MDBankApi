using System;
using System.Collections.Generic;
using System.Text;

namespace MDB.Domain.Entities
{
    public class ContaCorrente
    {
        public string Titular { get; set; } = "Jão Doido";
        public int Agencia { get; set; } = 1001;
        public int Numero { get; set; } = 123456789;
        public double Saldo { get; set; } = 500;
    }
}
