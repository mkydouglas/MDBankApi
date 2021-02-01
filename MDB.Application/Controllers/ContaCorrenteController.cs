using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MDB.Domain.Entities;
using MDB.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MDB.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private static ContaCorrente _contaCorrente = new ContaCorrente();
        private static ContaCorrente _contaCorrenteDestino = new ContaCorrente
        {
            Titular = "Fulano de Tal",
            Agencia = 1001,
            Numero = 987654321,
            Saldo = 200
        };
        private readonly IContaCorrenteService _contaCorrenteService;

        public ContaCorrenteController(IContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        public IActionResult Get()
        {
            return Ok(_contaCorrente);
        }

        [HttpPost("Sacar")]
        public async Task<IActionResult> Sacar([FromBody] double valor)
        {
            return Ok(await _contaCorrenteService.OperacaoSaque(valor, _contaCorrente));
        }

        [HttpPost("Depositar")]
        public async Task<IActionResult> Depositar([FromBody] double valor)
        {
            return Ok(await _contaCorrenteService.OperacaoDeposito(valor, _contaCorrente));
        }

        [HttpPost("Transferir")]
        public async Task<IActionResult> Transferir([FromBody] double valor)
        {
            return Ok(await _contaCorrenteService.OperacaoTransferencia(valor, _contaCorrente, _contaCorrenteDestino));
        }
    }
}
