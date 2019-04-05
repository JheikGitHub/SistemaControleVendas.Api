using SistemaControleVendas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaControleVendas.Dominio.Contratos
{
    public interface IVendaRepositorio : IDisposable
    {
        IEnumerable<Venda> Vendas();

        IEnumerable<Venda> VendasVendedor(int vendedorId);

        Venda Busca(int id);

        void Cadastro(Venda venda);

    }
}
