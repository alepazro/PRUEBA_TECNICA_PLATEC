using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Product.Service.Domain.Products.Entities;

namespace Product.Service.Infrastructure.Persistence.Contexts.Configurations
{
   
    public partial class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> entity)
        {
            entity.ToTable("Product");

            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.ProductId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .IsRequired()
                .IsUnicode(false);
            entity.Property(e => e.Quantity)
                .IsRequired()
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ProductEntity> entity);
    }

}
