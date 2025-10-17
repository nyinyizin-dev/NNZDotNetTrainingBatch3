// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using NNZDotNetTrainingBatch3.ConsoleApp2;
using System.Data;

Console.WriteLine("Hello, World!");

//ProductService productService = new ProductService();
//productService.Read();
//productService.Create();
//productService.Update();
//productService.Delete();

ProductDapperService productDapperService = new ProductDapperService();
productDapperService.Read();
productDapperService.Create();
productDapperService.Update();
productDapperService.Delete();

Console.ReadLine();


