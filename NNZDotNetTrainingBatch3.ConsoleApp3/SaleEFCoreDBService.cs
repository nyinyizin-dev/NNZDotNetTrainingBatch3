using NNZDotNetTrainingBatch3.ConsoleApp3.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp3
{
    public class SaleEFCoreDBService
    {
        private readonly AppDbContext _db;

        public SaleEFCoreDBService()
        {
            _db = new AppDbContext();
        }

        public void Read()
        {
            var lst = _db.TblSales.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].SaleId + ". " + lst[i].ProductId + " " + lst[i].Price);
            }
        }

        public void Create()
        {
            var item = new TblSale()
            {
                ProductId = 1,
                Quantity = 10,
                Price = 10000,
                DeleteFlag = false,
                CreatedDateTime = DateTime.Now
            };
            _db.TblSales.Add(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Success." : "Saving Failed.";
            Console.WriteLine(message);
        }

    }
}
