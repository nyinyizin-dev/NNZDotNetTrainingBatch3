using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp3
{
    public class ProductDapperService
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-EEBGV84",
            InitialCatalog = "MiniPOS",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"SELECT [ProductId]
            ,[ProductName]
            ,[Quantity]
            ,[Price]
            ,[DeleteFlag]
            ,[CreatedDateTime]
            ,[ModifiedDateTime]
             FROM [dbo].[Tbl_Product]";

             List<ProductDto> lst = db.Query<ProductDto>(query).ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    Console.WriteLine(lst[i].ProductId + ". " + lst[i].ProductName + " " + lst[i].Price);
                }
            }
        }
        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductName]
           ,[Quantity]
           ,[Price]
           ,[DeleteFlag]
           ,[CreatedDateTime]
           )
           VALUES
           ('newitem'
           ,10
           ,1000
           ,0
           ,GETDATE()
          )";

                int result = db.Execute(query);
                string message = result > 0 ? "Saving Success." : "Saving Failed.";
                Console.WriteLine(message);
            }
        }
        public void Update()
        {

            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"UPDATE [dbo].[Tbl_Product]
             SET [ProductName] = 'update one'
             ,[Quantity] = 20
             ,[Price] = 20000
             ,[ModifiedDateTime] = getdate()
             WHERE ProductId = 10";

                int result = db.Execute(query);
                string message = result > 0 ? "Updating Success." : "Updating Failed.";
                Console.WriteLine(message);
            }
        }
        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"Delete From Tbl_Product WHERE ProductId = 16;";

                int result = db.Execute(query);
                string message = result > 0 ? "Deleting Success." : "Deleting Failed.";
                Console.WriteLine(message);
            }
        }

    }

    public class ProductDto
    {
        // ,[ProductName]
        //    ,[Quantity]
        //    ,[Price]
        //    ,[DeleteFlag]
        //    ,[CreatedDateTime]
        //    ,[ModifiedDateTime]
        //FROM[dbo].[Tbl_Product]";

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public Boolean DeleteFlag { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
