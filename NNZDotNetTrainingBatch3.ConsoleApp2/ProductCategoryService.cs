using NNZDotNetTrainingBatch3.ConsoleApp2.Database.AppDbContextModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNZDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductCategoryService
    {
     public void Read()
        {
            AppDbContext db = new AppDbContext();
            db.TblProductCategories.ToList();
        }
    }
}
