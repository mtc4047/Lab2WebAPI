using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order : IEntityTypeConfiguration<Order>
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public ICollection<OrderPosition> OrderPositions { get; set; }
        public bool IsPaid { get; set; }
        public User? User { get; set; }
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(t => t.OrderPositions)
                .WithOne(t => t.Order)
                .HasForeignKey(t => t.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
