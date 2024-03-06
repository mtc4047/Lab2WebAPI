using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User : IEntityTypeConfiguration<User>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int TypeId {  get; set; }
        public bool IsActive { get; set; }
        public int GroupId { get; set; }
        public ICollection<BasketPosition>? BasketPositions { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Type Type { get; set; }

        public UserGroup UserGroup { get; set; }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(t => t.BasketPositions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(t => t.Orders)
                .WithOne(t=>t.User)
                .HasForeignKey(t => t.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
