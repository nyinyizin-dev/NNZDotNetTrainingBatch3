using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp3
{
    public class SaleEFCoreService
    {
        private readonly AppDbContext _db;
        public SaleEFCoreService()
        {
            _db = new AppDbContext();
        }

        public void Read()
        {
            var lst = _db.Sales.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].SaleId + ". " + lst[i].ProductId + " " + lst[i].Price);
            }
        }

        public void Create()
        {
            var item = new Tbl_Sale()
            {
                ProductId = 1,
                Quantity = 10,
                Price = 10000,
                DeleteFlag = false,
                CreatedDateTime = DateTime.Now
            };
            _db.Sales.Add(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Success." : "Saving Failed.";
            Console.WriteLine(message);
        }
    }
}
