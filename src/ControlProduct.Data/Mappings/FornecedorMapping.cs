using ControlProduct.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlProduct.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Documento)
                .HasColumnType("varchar(14)")
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(f => f.TipoFornecedor)
                .IsRequired()
                .HasColumnType("int");

            // 1 : 1 => Fornecedor - Endereco
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Fornecedor);

            // 1 : N => Fornecedor - Produtos
            builder.HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedores");

        }
    }
}
