using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductEFCoreService
    {
        //private readonly AppDbConetxt _db;

        public ProductEFCoreService()
        {
            //_db = new AppDbConetxt();
        }
        public void Read()
        {
            AppDbConetxt db = new AppDbConetxt();
            var lst = db.Products.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count; i++)
            {
                int rowNo = i + 1;
                Console.WriteLine(rowNo.ToString() + ". " + lst[i].ProductName + " " + lst[i].Price);
                //Console.WriteLine(lst[i].ProductId);
            }
        }
        public void Create()
        {
            AppDbConetxt db = new AppDbConetxt();
            var item = new Tbl_Product()
            {
                ProductName = "create apple",
                Price = 10000,
                Quantity = 100,
                CreatedDateTime = DateTime.Now,
                DeleteFlag = false,
            };
            db.Products.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saving Success." : "Saving Failed.";
            Console.WriteLine(message);

        }
        public void Update()
        {
            // linq for filter query
            AppDbConetxt db = new AppDbConetxt();
            //var item = db.Products.Where(x => x.ProductId == 9).FirstOrDefault();
            var item = db.Products.FirstOrDefault(x => x.ProductId == 9);
            if (item is null) return;

            item.ProductName = "update apple";
            item.ModifiedDateTime = DateTime.Now;
            int result = db.SaveChanges();

            string message = result > 0 ? "Updating Success." : "Updating Failed.";
            Console.WriteLine(message);
        }
        public void Delete()
        {
            AppDbConetxt db = new AppDbConetxt();
            var item = db.Products.FirstOrDefault(x => x.ProductId == 10);
            if (item is null) return;

            //db.Remove(item);
            item.DeleteFlag = true;
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }

    }
}
