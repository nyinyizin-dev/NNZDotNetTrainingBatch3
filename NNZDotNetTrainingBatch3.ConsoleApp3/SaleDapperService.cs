using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp3
{

    public class SaleDapperService
    {

        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-EEBGV84",
            InitialCatalog = "MiniPOS",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };

        public void Read() {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"SELECT [SaleId]
            ,[ProductId]
            ,[Quantity]
            ,[Price]
            ,[DeleteFlag]
            ,[CreatedDateTime]
             FROM [dbo].[Tbl_Sale]";

                List<SaleDto> lst = db.Query<SaleDto>(query).ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    Console.WriteLine(lst[i].SaleId + ". " + lst[i].ProductId + " " + lst[i].Quantity + " " + lst[i].Price + " " + lst[i].CreatedDateTime);
                }
            }
        }
        public void Create() {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"INSERT INTO [dbo].[Tbl_Sale]
           ([ProductId]
           ,[Quantity]
           ,[Price]
           ,[DeleteFlag]
           ,[CreatedDateTime])
            VALUES
           (1
           ,3
           ,3000
           ,0
           ,GETDATE())";

                int result = db.Execute(query);
                string message = result > 0 ? "Saving Success." : "Saving Failed.";
                Console.WriteLine(message);
            }
        }
    }

    public class SaleDto { 
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Boolean DeleteFlag { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
