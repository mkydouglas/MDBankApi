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
    public class ContaPoupancaController : ControllerBase
    {
        private static ContaPoupanca _contaPoupanca = new ContaPoupanca("Jão", 1001, 342423433, 500);
        private static ContaPoupanca _contaPoupancaDestino = new ContaPoupanca("Fulano de Tal", 1001, 987654321, 200);
        private readonly IContaPoupancaService _contaPoupancaService;

        public ContaPoupancaController(IContaPoupancaService contaPoupancaService)
        {
            _contaPoupancaService = contaPoupancaService;
        }

        public IActionResult Get()
        {
            return Ok(_contaPoupanca);
        }

        [HttpPost("Sacar")]
        public async Task<IActionResult> Sacar([FromBody] double valor)
        {
            return Ok(await _contaPoupancaService.OperacaoSaque(valor, _contaPoupanca));
        }

        [HttpPost("Depositar")]
        public async Task<IActionResult> Depositar([FromBody] double valor)
        {
            return Ok(await _contaPoupancaService.OperacaoDeposito(valor, _contaPoupanca));
        }

        [HttpPost("Transferir")]
        public async Task<IActionResult> Transferir([FromBody] double valor)
        {
            return Ok(await _contaPoupancaService.OperacaoTransferencia(valor, _contaPoupanca, _contaPoupancaDestino));
        }
    }
}
