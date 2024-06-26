﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product : IEntityTypeConfiguration<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image {  get; set; }
        public bool IsActive { get; set; }
        public int? GroupId { get; set; }

        public ICollection<BasketPosition>? BasketPositions { get; set; }

        public ProductGroup ProductGroup { get; set; }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(x => x.ProductGroup)
                .WithMany( x => x.Products)
                .HasForeignKey(x => x.GroupId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(d => d.BasketPositions)
            .WithOne(t => t.Product)
            .HasForeignKey(t => t.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
