using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp3
{
    public class ProductEFCoreService
    {
        private readonly ModelFirstAppDbContext _db;

        public ProductEFCoreService()
        {
            _db = new ModelFirstAppDbContext();
        }
        public void Read() 
        {
            var lst = _db.Products.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].ProductId + ". " + lst[i].ProductName + " " + lst[i].Price);
            }
        }

        public void Create()
        {
            var item = new Tbl_Product()
            {
                ProductName = "EFCoreCreate",
                Price = 10000,
                Quantity = 10,
                CreatedDateTime = DateTime.Now,
                DeleteFlag = false
            };
            _db.Products.Add(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Success." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update()
        {
          var item =  _db.Products.FirstOrDefault(x => x.ProductId == 5);
            if(item is null)
            {
                return;
            }

            item.ProductName = "EFCore Update";
            item.ModifiedDateTime = DateTime.Now;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Success." : "Updating Failed.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            var item = _db.Products.FirstOrDefault(x => x.ProductId == 6);
            if (item is null)
            {
                return;
            }

            //_db.Remove(item);
            item.DeleteFlag = true;
            item.ModifiedDateTime = DateTime.Now;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleting Success." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
