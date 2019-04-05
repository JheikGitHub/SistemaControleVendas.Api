using SistemaControleVendas.Dominio.Validaçoes;
using System;
using System.Collections.Generic;

namespace SistemaControleVendas.Dominio.Modelos
{
    public class Produto
    {

        #region Construtores

        protected Produto()
        {

        }

        public Produto(string descricao, double preco)
        {
            Descricao = descricao;
            PrecoUnitario = preco;
            DataCadastro = DateTime.Now;
        }
        #endregion

        #region Propriedades

        public int Id { get; set; }

        public string Descricao { get; set; }

        public double PrecoUnitario { get; set; }

        public DateTime DataCadastro { get; set; }

        #endregion

        #region Metodos

        public void AlteraProduto(string descricao, double preco)
        {
            Descricao = descricao;
            PrecoUnitario = preco;
           
            ValidaModelo();
        }

        public void ValidaModelo()
        {
            AssertionConcern.AssertArgumentNotEmpty(Descricao, $"Descrição do produto é inválida.");
            AssertionConcern.AssertArgumentRange(PrecoUnitario, 0, $"Preço unitario {PrecoUnitario} é inválido");
        }
        #endregion
    }
}
