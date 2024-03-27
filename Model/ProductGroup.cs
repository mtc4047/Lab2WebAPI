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

        public List<Product> Products { get; set; }

        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
