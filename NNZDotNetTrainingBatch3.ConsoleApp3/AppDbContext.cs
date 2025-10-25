using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp3
{
    public class ModelFirstAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-EEBGV84",
                InitialCatalog = "MiniPOS",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true,
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<Tbl_Product> Products { get; set; }
        public DbSet<Tbl_Sale> Sales { get; set; }
    }

    [Table("Tbl_Product")]
    public class Tbl_Product
    {
        [Key]
        public int ProductId { get; set; } // Primary Key, auto-incremented
        public string ProductName { get; set; } = string.Empty; // Required, max length 50
        public int Quantity { get; set; } // Required
        public decimal Price { get; set; } // Required, precision (18,0)
        public bool DeleteFlag { get; set; } // Required
        public DateTime CreatedDateTime { get; set; } // Required
        public DateTime? ModifiedDateTime { get; set; } // Optional
    }

    [Table("Tbl_Sale")]
    public class Tbl_Sale
    {
        [Key]
        public int SaleId { get; set; } // Primary Key, auto-incremented
        public int ProductId { get; set; } // Foreign Key reference to Product
        public int Quantity { get; set; } // Required
        public decimal Price { get; set; } // Required, precision (18,0)
        public bool DeleteFlag { get; set; } // Required
        public DateTime CreatedDateTime { get; set; } // Required
    }


}
