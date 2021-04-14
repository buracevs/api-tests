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
        public IEnumerable<Product> GetProducts();

    }
    public class DatabaseManager : IDatabaseManager
    {
        private readonly List<Product> _products;

        public DatabaseManager()
        {
            _products = new List<Product>(3)
            {
                new Product
                {
                    Id = 1, Title = "",Description = "", Price = 1.0m, ShortDescription = "", Images = new []{"122", "212"}
                },
                new Product
                {
                    Id = 2, Title = "",Description = "", Price = 1.0m, ShortDescription = "", Images = new []{"", ""}
                },
                new Product
                {
                    Id = 3, Title = "",Description = "", Price = 1.0m, ShortDescription = "", Images = new []{"", ""}
                },
            };


            Product[] product = new Product[2]
            {
                new Product
                {
                    Id = 1, Title = "",Description = "", Price = 1.0m, ShortDescription = "", Images = new []{"122", "212"}
                },
                new Product
                {
                    Id = 2, Title = "",Description = "", Price = 1.0m, ShortDescription = "", Images = new []{"", ""}
                }
            };
        }
        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
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
