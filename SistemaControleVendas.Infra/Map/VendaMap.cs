using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaControleVendas.Dominio.Modelos;

namespace SistemaControleVendas.Infra.Map
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Venda");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.VendedorId)
                .IsRequired();

            builder.Property(x => x.ProdutoId)
                .IsRequired();

            builder.Property(x => x.QuantidadeProduto)
                .IsRequired();

            builder.Property(x => x.ValorTotal)
                .IsRequired();

            builder.Property(x => x.DataCadastro)
                .HasColumnType("date")
                .IsRequired();
        }
    }
}
