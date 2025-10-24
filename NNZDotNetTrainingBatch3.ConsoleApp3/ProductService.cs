using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp3
{
    public class ProductService
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
            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"SELECT [ProductId]
            ,[ProductName]
            ,[Quantity]
            ,[Price]
            ,[DeleteFlag]
            ,[CreatedDateTime]
            ,[ModifiedDateTime]
             FROM [dbo].[Tbl_Product]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt); // execute 

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Price"]);
                Console.WriteLine(rowNo.ToString() + ". " + row["ProductName"] + " (" + price.ToString("n0") + " MMK)");
            }

            connection.Close();

        }
        public void Create()
        {
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

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Saving Success." : "Saving Failed.";

            Console.WriteLine(message);
        }
        public void Update() 
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
             SET [ProductName] = 'update one'
             ,[Quantity] = 20
             ,[Price] = 20000
             ,[ModifiedDateTime] = getdate()
             WHERE ProductId = 11";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Updating Success." : "Updating Failed.";

            Console.WriteLine(message);
        }
        public void Delete()
        {
            string query = @"Delete From Tbl_Product WHERE ProductId = 13;";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Deleting Success." : "Deleting Failed.";

            Console.WriteLine(message);
        }
    }
}
