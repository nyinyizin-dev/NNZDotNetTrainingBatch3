// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = "DESKTOP-EEBGV84"; // server name
sqlConnectionStringBuilder.InitialCatalog = "MiniPOS"; // database name
sqlConnectionStringBuilder.UserID = "sa"; // username
sqlConnectionStringBuilder.Password = "sasa@123"; // password
sqlConnectionStringBuilder.TrustServerCertificate = true;

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
    Console.WriteLine(rowNo.ToString() + ". " + row["ProductName"] + "(" + price.ToString("n0")  + ")");
    //Console.WriteLine(row["Quantity"]);
    //Console.WriteLine("Price => " + row["Price"]);
    Console.WriteLine("--------------------------");
}

//Console.ReadLine();


