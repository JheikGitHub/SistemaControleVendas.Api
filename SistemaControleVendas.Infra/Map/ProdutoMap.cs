using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaControleVendas.Dominio.Modelos;

namespace SistemaControleVendas.Infra.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro")
                .IsRequired();

            builder.Property(x => x.PrecoUnitario)
                .HasColumnName("PrecoUnitario")
                .IsRequired();

        }
    }
}

