using MDB.Domain.Entities;
using MDB.Domain.Interfaces;
using MDB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDB.Service.Services
{
    public class ContaPoupancaService : IContaPoupancaService
    {
        public async Task<ServiceResponse<ContaPoupanca>> OperacaoDeposito(double valor, ContaPoupanca contaPoupanca)
        {
            ServiceResponse<ContaPoupanca> serviceResponse = new ServiceResponse<ContaPoupanca>();

            contaPoupanca.Depositar(valor);

            serviceResponse.Data = contaPoupanca;
            serviceResponse.Message = "Depósito realizado com sucesso!";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ContaPoupanca>> OperacaoSaque(double valor, ContaPoupanca contaPoupanca)
        {
            ServiceResponse<ContaPoupanca> serviceResponse = new ServiceResponse<ContaPoupanca>();

            bool retorno = contaPoupanca.Sacar(valor);
            if (!retorno)
            {
                serviceResponse.Data = contaPoupanca;
                serviceResponse.Message = "Não foi possível concluir a transação. Seu saldo é inferior ao valor do saque!";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            serviceResponse.Data = contaPoupanca;
            serviceResponse.Message = "Saque realizado com sucesso!";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ContaPoupanca>> OperacaoTransferencia(double valor, ContaPoupanca contaTitular, ContaPoupanca contaDestino)
        {
            ServiceResponse<ContaPoupanca> serviceResponse = new ServiceResponse<ContaPoupanca>();

            bool retorno = contaTitular.Transferir(valor, contaDestino);
            if(!retorno)
            {
                serviceResponse.Data = contaTitular;
                serviceResponse.Message = "Não foi possível concluir a transação. Seu saldo é inferior ao valor que deseja transferir!";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            serviceResponse.Data = contaTitular;
            serviceResponse.Message = "Transferência realizada com sucesso!";
            return serviceResponse;

        }
    }
}
