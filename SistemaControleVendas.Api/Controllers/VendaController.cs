using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.Contratos.Servicos;
using SistemaControleVendas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaControleVendas.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/venda")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _service;


        public VendaController(IVendaService service)
        {
            _service = service;
        }

        [HttpGet("busca-venda/{id}")]
        public IActionResult BuscaVenda(int id)
        {
            var venda = _service.Busca(id);

            if (venda == null)
                return BadRequest("Venda não encontrada");

            return Ok(venda);
        }

        [HttpGet("busca-todos")]
        public IActionResult BuscaTodos()
        {
            var vendas = _service.BuscaTodos();
            return Ok(vendas);
        }

        [HttpPost("registra")]
        public IActionResult Registra([FromBody] Venda venda)
        {
            try
            {
                _service.Registrar(venda.VendedorId, venda.ProdutoId, venda.QuantidadeProduto, venda.ValorTotal);
                return Created("api/venda", venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}