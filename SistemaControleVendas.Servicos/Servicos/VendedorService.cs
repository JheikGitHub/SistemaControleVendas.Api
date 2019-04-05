using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.DTO;
using SistemaControleVendas.Dominio.Modelos;
using System.Collections.Generic;

namespace SistemaControleVendas.Servicos.Servicos
{
    public class VendedorService : IVendedorService
    {
        private readonly IVendedorRepositorio _repositorio;
        private readonly IVendaRepositorio _venda;

        public VendedorService(IVendedorRepositorio repositorio, IVendaRepositorio venda)
        {
            _repositorio = repositorio;
            _venda = venda;
        }

        public Vendedor Busca(int id)
        {
            return _repositorio.Buscar(id);
        }

        public IEnumerable<Vendedor> BuscaTodos()
        {
            return _repositorio.BuscaTodos();
        }

        public IEnumerable<VendedorComissao> Comissao()
        {
            ICollection<VendedorComissao> vendedors = new List<VendedorComissao>();

            var vendedores = BuscaTodos();

            foreach (var vendedor in vendedores)
            {
                VendedorComissao ven = new VendedorComissao();

                var lista = _venda.VendasVendedor(vendedor.Id);

                ven.Vendedor = vendedor.Nome;
                ven.Comissao = CalculaComissao(lista);

                vendedors.Add(ven);
            }

            return vendedors;

        }

        public double CalculaComissao(IEnumerable<Venda> vendasVendedor)
        {
            double comissao = 0;

            foreach (var venda in vendasVendedor)
            {
                comissao = (comissao + ((venda.Produto.PrecoUnitario * venda.QuantidadeProduto) * 0.05));
            }
            return comissao;
        }

        public void Dispose()
        {
            _venda.Dispose();
            _repositorio.Dispose();
        }

    }
}
