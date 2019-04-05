using SistemaControleVendas.Dominio.Modelos;
using System;
using System.Collections.Generic;

namespace SistemaControleVendas.Dominio.Contratos.Servicos
{
    public interface IProdutoService : IDisposable
    {
        Produto Busca(int id);

        IEnumerable<Produto> BuscaTodos();

        void Atualizar(int id,string descricao, double preco);

        void Registrar(string descricao, double preco);

        void Deletar(Produto produto);
    }
}
