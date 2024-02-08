using System;
using System.Collections.Generic;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class ProductCatalogueContext : DbContext
{
    public ProductCatalogueContext()
    {
    }

    public ProductCatalogueContext(DbContextOptions<ProductCatalogueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonCategory> PersonCategories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductBrand> ProductBrands { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Size> Size { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonCategory>(entity =>
        {
            entity.HasKey(e => e.PersonCategoryId).HasName("PK__PersonCa__DBAE2E9D79B8B93F");

            entity.ToTable("PersonCategory");

            entity.Property(e => e.PersonCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDB4A62BE4");

            entity.Property(e => e.ArticleNumber).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.PersonCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.PersonCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Person__5F141958");

            entity.HasOne(d => d.ProductBrand).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductBrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Produc__60FC61CA");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Produc__60083D91");

            entity.HasOne(d => d.Size).WithMany(p => p.Products)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__SizeId__5E1FF51F");
        });

        modelBuilder.Entity<ProductBrand>(entity =>
        {
            entity.HasKey(e => e.ProductBrandId).HasName("PK__ProductB__B195940996DA2CC1");

            entity.ToTable("ProductBrand");

            entity.Property(e => e.BrandName).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK__ProductC__3224ECCE60A59BD6");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.ProductCategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__Size__83BD097AAAA096ED");

            entity.ToTable("Size");

            entity.Property(e => e.SizeId).ValueGeneratedOnAdd();
            entity.Property(e => e.SizeofProduct)
                .HasMaxLength(20)
                .HasColumnName("Size");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
