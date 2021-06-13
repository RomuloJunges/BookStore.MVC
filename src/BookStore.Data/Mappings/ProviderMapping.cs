
using BookStore.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Mappings
{
    public class ProviderMapping : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(200)");
            builder.Property(p => p.Document).IsRequired().HasColumnType("varchar(14)");

            builder.HasOne(p => p.Address).WithOne(a => a.Provider);

            builder.HasMany(p => p.Products).WithOne(pr => pr.Provider).HasForeignKey(p => p.ProviderId);

            builder.ToTable("Providers");
        }
    }

}
