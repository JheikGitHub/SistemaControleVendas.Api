using SistemaControleVendas.Dominio.DTO;
using SistemaControleVendas.Dominio.Modelos;
using System;
using System.Collections.Generic;

namespace SistemaControleVendas.Dominio.Contratos
{
    public interface IVendedorService : IDisposable
    {
        Vendedor Busca(int id);

        IEnumerable<Vendedor> BuscaTodos();

        IEnumerable<VendedorComissao> Comissao();
    }
}
