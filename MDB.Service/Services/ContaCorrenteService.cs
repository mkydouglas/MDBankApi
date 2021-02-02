using MDB.Domain.Entities;
using MDB.Domain.Interfaces;
using MDB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MDB.Service.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        public async Task<ServiceResponse<ContaCorrente>> OperacaoDeposito(double valor, ContaCorrente contaCorrente)
        {
            ServiceResponse<ContaCorrente> serviceResponse = new ServiceResponse<ContaCorrente>();
            
            contaCorrente.Depositar(valor);

            serviceResponse.Data = contaCorrente;
            serviceResponse.Message = "Depósito realizado com sucesso!";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ContaCorrente>> OperacaoSaque(double valor, ContaCorrente contaCorrente)
        {
            ServiceResponse<ContaCorrente> serviceResponse = new ServiceResponse<ContaCorrente>();

            bool retorno = contaCorrente.Sacar(valor);
            if (!retorno)
            {
                serviceResponse.Data = contaCorrente;
                serviceResponse.Message = "Não foi possível concluir a transação. Seu saldo é inferior ao valor do saque!";
                serviceResponse.Success = false;
                return serviceResponse;
            }

            serviceResponse.Data = contaCorrente;
            serviceResponse.Message = "Saque realizado com sucesso!";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ContaCorrente>> OperacaoTransferencia(double valor, ContaCorrente contaTitular, ContaCorrente contaDestino)
        {
            ServiceResponse<ContaCorrente> serviceResponse = new ServiceResponse<ContaCorrente>();

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
