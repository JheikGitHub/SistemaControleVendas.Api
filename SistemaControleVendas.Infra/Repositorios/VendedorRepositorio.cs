using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.Modelos;
using SistemaControleVendas.Infra.ContextoDeDados;
using System.Collections.Generic;
using System.Linq;

namespace SistemaControleVendas.Infra.Repositorios
{
    public class VendedorRepositorio : IVendedorRepositorio
    {
        private readonly DbSistemaControleVendas _db;

        public VendedorRepositorio(DbSistemaControleVendas db)
        {
            _db = db;
        }

        public Vendedor Buscar(int id)
        {
            return _db.Vendedor.Find(id);
        }

        public void Atualiza(Vendedor vendedor)
        {
            _db.Entry(vendedor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<Vendedor> BuscaTodos()
        {
            return _db.Vendedor.ToList();
        }
    }
}
