using Microsoft.EntityFrameworkCore;

namespace zdzapi.Models
{
    public class EFDBContext : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(@"DataSource=database.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedor");
        }
    }
}
