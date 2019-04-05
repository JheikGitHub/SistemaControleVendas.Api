using SistemaControleVendas.Dominio.Modelos;
using System;
using System.Collections.Generic;

namespace SistemaControleVendas.Dominio.Contratos
{
    public interface IProdutoRepositorio : IDisposable
    {
        IEnumerable<Produto> BuscaTodos();

        Produto BuscaPorId(int id);

        IEnumerable<Produto> BuscaPorDescricao(string descricao);

        void Salvar(Produto produto);

        void Atualizar(Produto produto);

        void Deletar(Produto produto);

    }
}
