using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.ClienteId).HasColumnType("INT");
            builder.Property(p => p.LivroId).HasColumnType("INT");

            #region [Navegação]

            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasPrincipalKey(c => c.Id);

            builder.HasOne(p => p.Livro)
               .WithMany(c => c.Pedidos)
               .HasPrincipalKey(c => c.Id);

            #endregion
        }
    }
}
