using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaControleVendas.Dominio.Modelos;

namespace SistemaControleVendas.Infra.Map
{
    public class VendedorMap : IEntityTypeConfiguration<Vendedor>
    {
        public void Configure(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("Vendedor");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(150)")
                .IsRequired();
        }
    }
}
