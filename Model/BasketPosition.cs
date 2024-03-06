using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BasketPosition : IEntityTypeConfiguration<BasketPosition>
    {
        public int Id { get; set; }
        public int ProductId {  get; set; }
        public int UserId { get; set;}
        public int Amount { get; set; }
        
        public Product Product { get; set; }
        public User User { get; set; }
        public void Configure(EntityTypeBuilder<BasketPosition> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
