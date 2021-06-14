using BookStore.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Logradouro).IsRequired().HasColumnType("varchar(200)");
            builder.Property(a => a.Numero).IsRequired().HasColumnType("varchar(50)");
            builder.Property(a => a.CEP).IsRequired().HasColumnType("varchar(8)");
            builder.Property(a => a.Complemento).HasColumnType("varchar(250)");
            builder.Property(a => a.Bairro).IsRequired().HasColumnType("varchar(100)");
            builder.Property(a => a.Cidade).IsRequired().HasColumnType("varchar(100)");
            builder.Property(a => a.Estado).IsRequired().HasColumnType("varchar(50)");

            builder.ToTable("Addresses");
        }
    }

}
