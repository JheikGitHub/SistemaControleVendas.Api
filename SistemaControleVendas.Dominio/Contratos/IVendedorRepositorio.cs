using SistemaControleVendas.Dominio.Modelos;
using System;
using System.Collections.Generic;

namespace SistemaControleVendas.Dominio.Contratos
{
    public interface IVendedorRepositorio : IDisposable
    {
        Vendedor Buscar(int id);
        
        IEnumerable<Vendedor> BuscaTodos();

        void Atualiza(Vendedor vendedor);
    }
}
