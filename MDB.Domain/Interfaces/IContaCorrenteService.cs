using MDB.Domain.Entities;
using MDB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDB.Domain.Interfaces
{
    public interface IContaCorrenteService
    {
        Task<ServiceResponse<ContaCorrente>> OperacaoSaque(double valor, ContaCorrente contaCorrente);
        Task<ServiceResponse<ContaCorrente>> OperacaoDeposito(double valor, ContaCorrente contaCorrente);
        Task<ServiceResponse<ContaCorrente>> OperacaoTransferencia(double valor, ContaCorrente contaTitular, ContaCorrente contaDestino);
    }
}
