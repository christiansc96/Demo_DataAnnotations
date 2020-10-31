using Microsoft.EntityFrameworkCore;
using Demo_DataAnnotations.Models.DBModels;

namespace Demo_DataAnnotations.Context
{
    public partial class DevTeam504Context : DbContext
    {
        public DevTeam504Context()
        {
        }

        public DevTeam504Context(DbContextOptions<DevTeam504Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaCliente> CategoriaCliente { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLOCALDB;Database=DevTeam504Talk;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaCliente>(entity =>
            {
                entity.HasKey(e => e.CodCategoriaCliente)
                    .HasName("PK_CLCategoriaCliente");

                entity.Property(e => e.CodCategoriaCliente).HasColumnName("codCategoriaCliente");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.DescripcionCategoriaCliente)
                    .IsRequired()
                    .HasColumnName("descripcionCategoriaCliente")
                    .HasMaxLength(900);

                entity.Property(e => e.NombreCategoriaCliente)
                    .IsRequired()
                    .HasColumnName("nombreCategoriaCliente")
                    .HasMaxLength(900);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.CodCliente)
                    .HasName("PK_CLClientes");

                entity.Property(e => e.CodCliente).HasColumnName("codCliente");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodCategoriaCliente).HasColumnName("codCategoriaCliente");

                entity.Property(e => e.ContactoPrincipal)
                    .HasColumnName("contactoPrincipal")
                    .HasMaxLength(900);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correoElectronico");

                entity.Property(e => e.DireccionNegocio).HasColumnName("direccionNegocio");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasColumnName("nombreCliente")
                    .HasMaxLength(900);

                entity.Property(e => e.NombreNegocio)
                    .HasColumnName("nombreNegocio")
                    .HasMaxLength(900);

                entity.Property(e => e.NumeroTelefono)
                    .IsRequired()
                    .HasColumnName("numeroTelefono")
                    .HasMaxLength(50);

                entity.Property(e => e.Rtn)
                    .HasColumnName("RTN")
                    .HasMaxLength(900);

                entity.HasOne(d => d.CodCategoriaClienteNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodCategoriaCliente);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correoElectronico")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasColumnName("nombres")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroCelular)
                    .IsRequired()
                    .HasColumnName("numeroCelular")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}