using BlogViajesModelo;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogViajes.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Carrito> Carrito { get; set; } 
    public DbSet<CarritoDetalle> CarritoDetalle { get;set; }
    public DbSet<Compra> Compra { get; set; }
    public DbSet<CompraDetalle> CompraDetalle { get; set; }
    public DbSet<Destino> Destino { get; set; }
    public DbSet<OpcionesDePago> OpcionesDePagos { get; set; }
    public DbSet<PaqueteDeViaje> PaqueteDeViajes { get; set; }
    public DbSet<PaqueteOpcionesPago> PaqueteOpcionesPagos { get; set; }
    public DbSet<ViajeDestino> ViajeDestino { get;set; }
    public DbSet<Slider> Slider { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ViajeDestino>()
            .HasOne(vd => vd.IdPaqueteNavigation)
            .WithMany(p => p.Destino)
            .HasForeignKey(vd => vd.IdPaqueteViaje)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ViajeDestino>()
            .HasOne(vd => vd.IdDestinoNavigation)
            .WithMany()
            .HasForeignKey(vd => vd.IdDestino)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
