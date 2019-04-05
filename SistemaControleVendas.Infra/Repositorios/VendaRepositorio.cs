using Microsoft.EntityFrameworkCore;
using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.Modelos;
using SistemaControleVendas.Infra.ContextoDeDados;
using System.Collections.Generic;
using System.Linq;

namespace SistemaControleVendas.Infra.Repositorios
{
    public class VendaRepositorio : IVendaRepositorio
    {
        private readonly DbSistemaControleVendas _db;

        public VendaRepositorio(DbSistemaControleVendas db)
        {
            _db = db;
        }

        public IEnumerable<Venda> Vendas()
        {
            return _db.Vendas.Include(x => x.Produto).ToList();
        }

        public void Cadastro(Venda venda)
        {
            _db.Vendas.Add(venda);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public Venda Busca(int id)
        {
            return _db.Vendas.Find(id);
        }

        public IEnumerable<Venda> VendasVendedor(int vendedorId)
        {
            return _db.Vendas.Where(x => x.VendedorId == vendedorId).Include(x => x.Produto).ToList();
        }
    }
}
