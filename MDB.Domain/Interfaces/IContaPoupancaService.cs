using MDB.Domain.Entities;
using MDB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDB.Domain.Interfaces
{
    public interface IContaPoupancaService
    {
        Task<ServiceResponse<ContaPoupanca>> OperacaoSaque(double valor, ContaPoupanca contaCorrente);
        Task<ServiceResponse<ContaPoupanca>> OperacaoDeposito(double valor, ContaPoupanca contaCorrente);
        Task<ServiceResponse<ContaPoupanca>> OperacaoTransferencia(double valor, ContaPoupanca contaTitular, ContaPoupanca contaDestino);
    }
}
