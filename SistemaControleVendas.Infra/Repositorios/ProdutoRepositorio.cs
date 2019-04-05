using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.Modelos;
using SistemaControleVendas.Infra.ContextoDeDados;
using System.Collections.Generic;
using System.Linq;

namespace SistemaControleVendas.Infra.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly DbSistemaControleVendas _db;

        public ProdutoRepositorio(DbSistemaControleVendas db)
        {
            _db = db;
        }

        public Produto BuscaPorId(int id)
        {
            return _db.Produtos.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Produto> BuscaPorDescricao(string descricao)
        {
            return _db.Produtos.Where(x => x.Descricao.ToLower().Contains(descricao.ToLower())).ToList();
        }

        public IEnumerable<Produto> BuscaTodos()
        {
            return _db.Produtos.ToList();
        }

        public void Salvar(Produto produto)
        {
            _db.Produtos.Add(produto);
            _db.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            _db.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Deletar(Produto produto)
        {
            _db.Remove(produto);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }


    }
}
