using System;
using System.Collections.Generic;
using System.Text;

namespace MDB.Domain.Entities
{
    public class ContaPoupanca
    {
        public string Titular { get; set; } = "Jão Doido";
        public int Agencia { get; set; } = 1001;
        public int Numero { get; set; } = 111222333;
        public double Saldo { get; set; } = 200;
    }
}
