using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductService
    {   
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-EEBGV84",
            InitialCatalog = "MiniPOS",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate= true,

        };
        public void Read()
        {
            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilder.DataSource = "DESKTOP-EEBGV84"; // server name
            //sqlConnectionStringBuilder.InitialCatalog = "MiniPOS"; // database name
            //sqlConnectionStringBuilder.UserID = "sa"; // username
            //sqlConnectionStringBuilder.Password = "sasa@123"; // password
            //sqlConnectionStringBuilder.TrustServerCertificate = true;

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"SELECT [ProductId]
              ,[ProductName]
              ,[Quantity]
              ,[Price]
              ,[DeleteFlag]
                FROM [dbo].[Tbl_Product]";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt); // execute 

            connection.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                //Console.WriteLine(row["ProductId"]);
                int rowNo = i + 1;
                decimal price = Convert.ToDecimal(row["Price"]);
                Console.WriteLine(rowNo.ToString() + ". " + row["ProductName"] + " (" + price.ToString("n0") + " MMK)");
                //Console.WriteLine(row["Quantity"]);
                //Console.WriteLine("Price=> " + row["Price"]);
                //Console.WriteLine("-----------------");
            }
        }

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductName]
           ,[Quantity]
           ,[Price]
           ,[DeleteFlag])
             VALUES
           ('NewOne'
           ,10
           ,30000
           ,0)";

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
         SET [ProductName] = 'UpateOne'
        ,[Quantity] = 10
        ,[Price] = 2000
        ,[DeleteFlag] = 1
         WHERE ProductId = 6";

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
            string query = @"Delete From Tbl_Product WHERE ProductId = 7;";

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
