using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Custo0.Domains;

#nullable disable

namespace Custo0.Contexts
{
    public partial class Cust0Context : DbContext
    {
        public Cust0Context()
        {
        }

        public Cust0Context(DbContextOptions<Cust0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<SituacaoReserva> SituacaoReservas { get; set; }
        public virtual DbSet<TipoProduto> TipoProdutos { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0BA1Q0M\\SQLEXPRESS; initial catalog=custo; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__885457EEB6B3D993");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("documento");

                entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Cliente__idEnder__2F10007B");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Cliente__idUsuar__2E1BDC42");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__75D2CED4FC7D9C06");

                entity.ToTable("Empresa");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.ImagemEmpresa)
                    .HasMaxLength(74)
                    .IsUnicode(false)
                    .HasColumnName("imagemEmpresa");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Empresa__idEnder__32E0915F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Empresa__idUsuar__31EC6D26");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__E45B8B2781E97B24");

                entity.ToTable("Endereco");

                entity.Property(e => e.IdEndereco).HasColumnName("idEndereco");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cep");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(74)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__Endereco__idEsta__2B3F6F97");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado__62EA894A496F85D8");

                entity.ToTable("Estado");

                entity.Property(e => e.IdEstado)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEstado");

                entity.Property(e => e.NomeEstado)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nomeEstado");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__5EEDF7C383F8FCD4");

                entity.ToTable("Produto");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.DataValidade)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataValidade");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(470)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdTipoProduto).HasColumnName("idTipoProduto");

                entity.Property(e => e.ImagemProduto)
                    .HasMaxLength(74)
                    .IsUnicode(false)
                    .HasColumnName("imagemProduto");

                entity.Property(e => e.Preco).HasColumnName("preco");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Produto__idEmpre__38996AB5");

                entity.HasOne(d => d.IdTipoProdutoNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdTipoProduto)
                    .HasConstraintName("FK__Produto__idTipoP__37A5467C");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reserva__94D104C8DB30B548");

                entity.ToTable("Reserva");

                entity.Property(e => e.IdReserva).HasColumnName("idReserva");

                entity.Property(e => e.DataSolicitacao)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataSolicitacao");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.IdSituacao).HasColumnName("idSituacao");

                entity.Property(e => e.Preco).HasColumnName("preco");

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Reserva__idClien__403A8C7D");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Reserva__idEmpre__3F466844");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Reserva__idProdu__3E52440B");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Reserva__idSitua__3D5E1FD2");
            });

            modelBuilder.Entity<SituacaoReserva>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoReserva)
                    .HasName("PK__situacao__4F2B94CA508A365C");

                entity.ToTable("situacaoReserva");

                entity.Property(e => e.IdSituacaoReserva)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacaoReserva");

                entity.Property(e => e.TituloReserva)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tituloReserva");
            });

            modelBuilder.Entity<TipoProduto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProduto)
                    .HasName("PK__tipoProd__DE38B032918D2181");

                entity.ToTable("tipoProduto");

                entity.Property(e => e.IdTipoProduto)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoProduto");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF6BF3B61D");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6A836537C");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(266)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
