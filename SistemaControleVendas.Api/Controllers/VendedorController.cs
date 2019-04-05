using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaControleVendas.Api.Controllers
{
    [Route("api/vendedor")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _vendedorService;

        public VendedorController(IVendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        [HttpGet("busca-todos")]
        public IEnumerable<Vendedor> BuscaTodos()
        {
            return _vendedorService.BuscaTodos();
        }

        [HttpGet("comissao")]
        public IActionResult Comissao()
        {
            try
            {
                return Ok(_vendedorService.Comissao());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}