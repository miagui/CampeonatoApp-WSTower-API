using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApiWsTower.Domains;

namespace WebApiWsTower.Contexts
{
    public partial class CampeonatoContext : DbContext
    {
        public CampeonatoContext()
        {
        }

        public CampeonatoContext(DbContextOptions<CampeonatoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jogador> Jogador { get; set; }
        public virtual DbSet<Jogo> Jogo { get; set; }
        public virtual DbSet<Selecao> Selecao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-BEVTDEI\\TSQLEXPRESS; Initial Catalog=Campeonato; user Id=sa; pwd=sa@123;");
                optionsBuilder.UseSqlServer("Server=localhost; Initial Catalog=Campeonato;Integrated Security=SSPI;Persist Security Info=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogador>(entity =>
            {
                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.Informacoes)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Nascimento).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Posicao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QtdecartoesAmarelo).HasColumnName("QTDECartoesAmarelo");

                entity.Property(e => e.QtdecartoesVermelho).HasColumnName("QTDECartoesVermelho");

                entity.Property(e => e.Qtdefaltas).HasColumnName("QTDEFaltas");

                entity.Property(e => e.Qtdegols).HasColumnName("QTDEGols");

                entity.Property(e => e.SelecaoId).HasColumnName("SelecaoID");

                entity.HasOne(d => d.Selecao)
                    .WithMany(p => p.Jogador)
                    .HasForeignKey(d => d.SelecaoId)
                    .HasConstraintName("FK__Jogador__Selecao__3D5E1FD2");
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Estadio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.SelecaoCasaNavigation)
                    .WithMany(p => p.JogoSelecaoCasaNavigation)
                    .HasForeignKey(d => d.SelecaoCasa)
                    .HasConstraintName("FK__Jogo__SelecaoCas__403A8C7D");

                entity.HasOne(d => d.SelecaoVisitanteNavigation)
                    .WithMany(p => p.JogoSelecaoVisitanteNavigation)
                    .HasForeignKey(d => d.SelecaoVisitante)
                    .HasConstraintName("FK__Jogo__SelecaoVis__412EB0B6");
            });

            modelBuilder.Entity<Selecao>(entity =>
            {
                entity.Property(e => e.Bandeira).HasColumnType("image");

                entity.Property(e => e.Escalacao)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uniforme).HasColumnType("image");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Apelido)
                    .HasName("UQ__Usuario__571DBAE6B91CEE86")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D1053490D0C733")
                    .IsUnique();

                entity.Property(e => e.Apelido)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
