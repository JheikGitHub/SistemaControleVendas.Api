using SistemaControleVendas.Dominio.Modelos;
using System;
using System.Collections.Generic;

namespace SistemaControleVendas.Dominio.Contratos.Servicos
{
    public interface IVendaService : IDisposable
    {
        Venda Busca(int id);

        IEnumerable<Venda> BuscaTodos();

        void Registrar(int vendedorId, int produtoId, int ValorTotal, double valortotal);

    }
}
