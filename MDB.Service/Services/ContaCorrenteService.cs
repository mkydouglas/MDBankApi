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
            
            contaCorrente.Saldo = Depositar(valor, contaCorrente.Saldo);

            serviceResponse.Data = contaCorrente;
            serviceResponse.Message = "Depósito realizado com sucesso!";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ContaCorrente>> OperacaoSaque(double valor, ContaCorrente contaCorrente)
        {
            ServiceResponse<ContaCorrente> serviceResponse = new ServiceResponse<ContaCorrente>();

            bool retorno = Sacar(valor, contaCorrente);
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

            bool retorno = Transferir(valor, contaTitular, contaDestino);
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

        private bool Sacar(double valor, ContaCorrente conta)
        {
            if(valor > conta.Saldo)
            {
                return false;
            }

            conta.Saldo -= valor;
            return true;
        }

        private double Depositar(double valor, double saldo)
        {
            return saldo += valor;
        }

        private bool Transferir(double valor, ContaCorrente contaTitular, ContaCorrente contaDestino)
        {
            bool retorno = Sacar(valor, contaTitular);
            if (!retorno)
            {
                return false;
            }

            contaDestino.Saldo += valor;
            return true;
        }
    }
}
