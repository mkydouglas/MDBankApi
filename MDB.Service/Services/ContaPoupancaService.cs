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
        public async Task<ServiceResponse<ContaPoupanca>> OperacaoDeposito(double valor, ContaPoupanca contaCorrente)
        {
            ServiceResponse<ContaPoupanca> serviceResponse = new ServiceResponse<ContaPoupanca>();
            
            contaCorrente.Saldo = Depositar(valor, contaCorrente.Saldo);

            serviceResponse.Data = contaCorrente;
            serviceResponse.Message = "Depósito realizado com sucesso!";

            return serviceResponse;
        }

        public async Task<ServiceResponse<ContaPoupanca>> OperacaoSaque(double valor, ContaPoupanca contaCorrente)
        {
            ServiceResponse<ContaPoupanca> serviceResponse = new ServiceResponse<ContaPoupanca>();

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

        public async Task<ServiceResponse<ContaPoupanca>> OperacaoTransferencia(double valor, ContaPoupanca contaTitular, ContaPoupanca contaDestino)
        {
            ServiceResponse<ContaPoupanca> serviceResponse = new ServiceResponse<ContaPoupanca>();

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

        private bool Sacar(double valor, ContaPoupanca conta)
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

        private bool Transferir(double valor, ContaPoupanca contaTitular, ContaPoupanca contaDestino)
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
