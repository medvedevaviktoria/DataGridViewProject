using DataGridViewProject.Constants;
using DataGridViewProject.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataGridViewProject.DataBaseStorage
{
    public class DataGridViewProjectContext : DbContext
    {
        /// <summary>
        /// Сущность <see cref="ProductModel"/>.
        /// </summary>
        public DbSet<ProductModel> Products { get; set; }

        /// <summary>
        /// Создаёт экземпляр <see cref="DataGridViewProjectContext"/>.
        /// </summary>
        public DataGridViewProjectContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\mssqllocaldb;Database=DataGridViewProjectDatabase;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>(entity =>
            {
                // PK
                entity.HasKey(e => e.Id);

                // Наименование
                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(AppConstants.ProductNameMaxLength);

                // Размер
                entity.Property(e => e.ProductSize)
                    .IsRequired()
                    .HasMaxLength(AppConstants.ProductSizeMaxLength);

                // enum Material как int
                entity.Property(e => e.Material)
                    .HasConversion<int>();

                // Количества
                entity.Property(e => e.Quantity);
                entity.Property(e => e.MinQuantity);

                // Цена
                entity.Property(e => e.PriceWithoutTax);
            });
        }

    }
}