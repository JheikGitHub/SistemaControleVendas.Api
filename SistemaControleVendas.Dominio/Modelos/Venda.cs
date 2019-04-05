using SistemaControleVendas.Dominio.Validaçoes;
using System;

namespace SistemaControleVendas.Dominio.Modelos
{
    public class Venda
    {
        #region Construtores
        protected Venda()
        {
        }

        public Venda(int vendedorId, int produtoId, int quantidade, double valortotal)
        {
            VendedorId = vendedorId;
            ProdutoId = produtoId;
            QuantidadeProduto = quantidade;
            ValorTotal = valortotal;
            DataCadastro = DateTime.Now;
        }
        #endregion

        #region Propriedade
        public int Id { get; set; }


        public DateTime DataCadastro { get; set; }

        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public int QuantidadeProduto { get; set; }

        public double ValorTotal { get; set; }

        #endregion

        #region Metodos
        public void ValidaModelo()
        {
            AssertionConcern.AssertArgumentRange(VendedorId, 0, "Codigo do vendedor é inválido");
            AssertionConcern.AssertArgumentRange(ProdutoId, 0, "Codigo do produto é inválido");
            AssertionConcern.AssertArgumentRange(QuantidadeProduto, 0, "Quantidade é inválida");
            AssertionConcern.AssertArgumentRange(ValorTotal, 0, "Valor total é inválido");
        }
        #endregion
    }
}
