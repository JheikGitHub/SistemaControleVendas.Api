using SistemaControleVendas.Dominio.Validaçoes;
using System.Collections.Generic;

namespace SistemaControleVendas.Dominio.Modelos
{
    public class Vendedor
    {
        #region Construtores
        protected Vendedor()
        {

        }

        public Vendedor(string nome)
        {
            Nome = nome;
        }
        #endregion

        #region Propriedades

        public int Id { get; set; }

        public string Nome { get; set; }

        #endregion

        #region Metodos

        void AlterarVendedor(string nome)
        {
            Nome = nome;
            ValidaModelo();
        }

        void ValidaModelo()
        {
            AssertionConcern.AssertArgumentNotEmpty(Nome, "Nome inválido.");
        }
        #endregion
    }
}

