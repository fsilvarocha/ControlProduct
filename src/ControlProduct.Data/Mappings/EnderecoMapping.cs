using ControlProduct.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlProduct.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .HasColumnType("varchar(150)")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Numero)
                .HasColumnType("varchar(15)")
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(e => e.Bairro)
                .HasColumnType("varchar(150)")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Cep)
                .HasColumnType("varchar(8)")
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(e => e.Cidade)
                .HasColumnType("varchar(150)")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(e => e.Estado)
                .HasColumnType("varchar(30)")
                .IsRequired()
                .HasMaxLength(30);

            builder.ToTable("Enderecos");
        }
    }
}
