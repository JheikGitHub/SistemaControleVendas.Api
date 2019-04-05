using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.Contratos.Servicos;
using SistemaControleVendas.Dominio.Modelos;
using System.Collections.Generic;

namespace SistemaControleVendas.Servicos.Servicos
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepositorio _repositorio;

        public VendaService(IVendaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Venda Busca(int id)
        {
            return _repositorio.Busca(id);
        }

        public IEnumerable<Venda> BuscaTodos()
        {
            return _repositorio.Vendas();
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public void Registrar(int vendedorId, int produtoId, int quantidade, double valortotal)
        {
            var venda = new Venda(vendedorId, produtoId, quantidade, valortotal);
            venda.ValidaModelo();

            _repositorio.Cadastro(venda);
        }
    }
}
