using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Type : IEntityTypeConfiguration<Type>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }

        public void Configure(EntityTypeBuilder<Type> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(t => t.Users)
                .WithOne(t => t.Type)
                .HasForeignKey(t => t.TypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
