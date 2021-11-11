using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication2.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aeroporto> Aeroportos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Quarto> Quartos { get; set; }
        public virtual DbSet<ReservaHotel> ReservaHotels { get; set; }
        public virtual DbSet<ReservaPassagem> ReservaPassagems { get; set; }
        public virtual DbSet<Voo> Voos { get; set; }
        public object Aeroporto { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=SINSAON1666\\SQLEXPRESS;initial catalog=projetoAeroportoHotel;trusted_connection=true");
                //"Breno": "Data Source=SINSAON1666\\SQLEXPRESS;Initial Catalog=Projeto_Loja_Sapatos;Integrated Security=True",
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aeroporto>(entity =>
            {
                entity.ToTable("Aeroporto");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.HasIndex(e => e.Cpf, "UQ__Cliente__C1F89731E1E8A698")
                    .IsUnique();

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.DataNasc).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("Hotel");

                entity.HasIndex(e => e.Cnpj, "UQ__Hotel__AA57D6B4848BB158")
                    .IsUnique();

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj).HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Quarto>(entity =>
            {
                entity.ToTable("Quarto");

                entity.Property(e => e.Descrição)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TipoQuarto)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValorDiaria).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdHotelNavigation)
                    .WithMany(p => p.Quartos)
                    .HasForeignKey(d => d.IdHotel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Quarto__ValorDia__2A4B4B5E");
            });

            modelBuilder.Entity<ReservaHotel>(entity =>
            {
                entity.ToTable("ReservaHotel");

                entity.Property(e => e.DtCheckin).HasColumnType("datetime");

                entity.Property(e => e.DtCheckout).HasColumnType("datetime");

                entity.Property(e => e.ValorTotal).HasColumnType("decimal(18, 0)");

                //entity.HasOne(d => d.IdClienteNavigation)
                //    .WithMany(p => p.ReservaHotels)
                //    .HasForeignKey(d => d.IdCliente)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__ReservaHo__Valor__2D27B809");

                entity.HasOne(d => d.IdQuartoNavigation)
                    .WithMany(p => p.ReservaHotels)
                    .HasForeignKey(d => d.IdQuarto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReservaHo__IdQua__2E1BDC42");
            });

            modelBuilder.Entity<ReservaPassagem>(entity =>
            {
                entity.ToTable("ReservaPassagem");

                //entity.HasOne(d => d.IdClienteNavigation)
                //    .WithMany(p => p.ReservaPassagems)
                //    .HasForeignKey(d => d.IdCliente)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__ReservaPa__IdCli__37A5467C");

                entity.HasOne(d => d.IdVooNavigation)
                    .WithMany(p => p.ReservaPassagems)
                    .HasForeignKey(d => d.IdVoo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReservaPa__IdVoo__36B12243");
            });

            modelBuilder.Entity<Voo>(entity =>
            {
                entity.ToTable("Voo");

                entity.Property(e => e.DateTimeChegada).HasColumnType("datetime");

                entity.Property(e => e.DateTimePartida).HasColumnType("datetime");

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdAeroportoDestinoNavigation)
                    .WithMany(p => p.VooIdAeroportoDestinoNavigations)
                    .HasForeignKey(d => d.IdAeroportoDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Voo__IdAeroporto__33D4B598");

                entity.HasOne(d => d.IdAeroportoOrigemNavigation)
                    .WithMany(p => p.VooIdAeroportoOrigemNavigations)
                    .HasForeignKey(d => d.IdAeroportoOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Voo__IdAeroporto__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
