using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Order>? Order { get; set; }
    public DbSet<Volume>? Volume { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
      //categoria
      mb.Entity<Volume>().HasKey(c => c.VolumeId);
      mb.Entity<Volume>().Property(c => c.Nome)
                            .HasMaxLength(100)
                            .IsRequired();
      mb.Entity<Volume>().Property(c => c.Descricao).HasMaxLength(150).IsRequired();

      //produto
      mb.Entity<Order>().HasKey(c => c.ProdutoId);
      mb.Entity<Order>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
      mb.Entity<Order>().Property(c => c.Descricao).HasMaxLength(150);
      mb.Entity<Order>().Property(c => c.Imagem).HasMaxLength(100);
      mb.Entity<Order>().Property(c => c.Preco).HasPrecision(14, 2);

      //relacionamento
      mb.Entity<Order>()
          .HasOne<Volume>(c => c.Volume)
            .WithMany(p => p.Order)
              .HasForeignKey(c => c.VolumeId);
    }
  }
}
