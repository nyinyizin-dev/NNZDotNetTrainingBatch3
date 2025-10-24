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
    public class SaleService
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

            string query = @"SELECT [SaleId]
            ,[ProductId]
            ,[Quantity]
            ,[Price]
            ,[DeleteFlag]
            ,[CreatedDateTime]
             FROM [dbo].[Tbl_Sale]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt); // execute 

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Price"]);
                Console.WriteLine(rowNo.ToString() + ". " + row["ProductId"] + " " + row["Quantity"] + " " + price.ToString("n0") + " MMK");
            }


            connection.Close();
        }
        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Sale]
           ([ProductId]
           ,[Quantity]
           ,[Price]
           ,[DeleteFlag]
           ,[CreatedDateTime])
            VALUES
           (1
           ,5
           ,1000
           ,0
           ,GETDATE())";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Saving Success." : "Saving Failed.";

            Console.WriteLine(message);
        }

    }
}
