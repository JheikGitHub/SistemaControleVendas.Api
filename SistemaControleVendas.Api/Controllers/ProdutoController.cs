using Microsoft.AspNetCore.Mvc;
using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.Contratos.Servicos;
using SistemaControleVendas.Dominio.Modelos;
using System;

namespace SistemaControleVendas.Api.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;

        }

        [HttpGet("busca-todos")]
        public IActionResult BuscaTodos()
        {
            return Ok(_service.BuscaTodos());
        }

        [HttpGet("busca-produto/{id}")]
        public IActionResult BuscaProduto(int id)
        {
            var produto = _service.Busca(id);

            if (produto == null)
                return BadRequest("Produto não encontrado.");

            return Ok(produto);
        }

        [HttpPost("registra")]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                _service.Registrar(produto.Descricao, produto.PrecoUnitario);
                return Created("api/produto",
                    new { descricao = produto.Descricao, preco = produto.PrecoUnitario, dataCadastro = produto.DataCadastro });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("atualiza/{id}")]
        public IActionResult Atualiza(int id, [FromBody] Produto produto)
        {
            try
            {
                _service.Atualizar(id, produto.Descricao, produto.PrecoUnitario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove/{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _service.Busca(id);

            if (produto == null)
                return BadRequest("Produto não encontrado");

            try
            {
                _service.Deletar(produto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
