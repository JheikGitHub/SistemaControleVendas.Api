using Microsoft.EntityFrameworkCore;
using SistemaControleVendas.Dominio.Modelos;
using SistemaControleVendas.Infra.Map;

namespace SistemaControleVendas.Infra.ContextoDeDados
{
    public class DbSistemaControleVendas : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DbSistemaControleVendas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
            modelBuilder.ApplyConfiguration(new VendedorMap());

            base.OnModelCreating(modelBuilder);
        }
    }

}
