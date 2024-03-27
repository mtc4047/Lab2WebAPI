using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model
{
    public class OrderPosition : IEntityTypeConfiguration<OrderPosition>
    {
        public int Id { get; set; }
        public int OrderId {  get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }

        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(t => t.Order)
            .WithMany(t => t.OrderPositions)
            .HasForeignKey(t => t.Id)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
