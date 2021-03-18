using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Controllers;
using web_api.ViewModels;

namespace web_api.BL
{
    public interface IDatabaseManager
    {
        public int SaveOne(TestObjectToSave tst);
        public int SaveTwo();
        public ViewModels.Product GetProduct(int id);

    }
    public class DatabaseManager : IDatabaseManager
    {
        public Product GetProduct(int id)
        {
            return new Product
            {
                Id = 1,
                Title = "hello",
                Description = "Lorem ipsum"
            };
        }

        public int SaveOne(TestObjectToSave tst)
        {
            //return 0 saved 1 not saved
            return 1;
        }

        public int SaveTwo()
        {
            //return 0 saved 1 not saved
            return 1;
        }
    }
}
