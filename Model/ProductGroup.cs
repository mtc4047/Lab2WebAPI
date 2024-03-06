using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductGroup:IEntityTypeConfiguration<ProductGroup>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentID { get; set; }

        public ICollection<Product>? Products { get; set; }
        public ProductGroup? ParentGroup { get; set; }
        public ICollection<ProductGroup> Groups { get; set; }
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(d => d.Products)
                .WithOne(t => t.ProductGroup)
                .HasForeignKey(t => t.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(d => d.Groups)
                .WithOne(d => d.ParentGroup)
                .HasForeignKey(d => d.ParentID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
