using SistemaControleVendas.Dominio.Contratos;
using SistemaControleVendas.Dominio.Contratos.Servicos;
using SistemaControleVendas.Dominio.Modelos;
using System.Collections.Generic;

namespace SistemaControleVendas.Servicos.Servicos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositorio _repositorio;

        public ProdutoService(IProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public void Atualizar(int id, string descricao, double preco)
        {
            var produto = Busca(id);

            produto.AlteraProduto(descricao, preco);
            produto.ValidaModelo();

            _repositorio.Atualizar(produto);
        }

        public Produto Busca(int id)
        {
            return _repositorio.BuscaPorId(id);
        }

        public IEnumerable<Produto> BuscaTodos()
        {
            return _repositorio.BuscaTodos();
        }

        public void Deletar(Produto produto)
        {
            _repositorio.Deletar(produto);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public void Registrar(string descricao, double preco)
        {
            var produto = new Produto(descricao, preco);
            produto.ValidaModelo();

            _repositorio.Salvar(produto);
        }
    }
}
