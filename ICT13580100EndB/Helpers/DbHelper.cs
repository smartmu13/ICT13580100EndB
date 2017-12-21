using System;
using System.Collections.Generic;
using System.Linq;
using ICT13580100EndB.Models;
using SQLite;
namespace ICT13580100EndB.Helpers
                         

                         
{
    public class DbHelper
    {
        SQLiteConnection db;

        public DbHelper(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<ProductCar>();
        }

        public int AddProduct(ProductCar carProduct)
        {
             db.Insert(carProduct);
            return carProduct.Id;
        }

        public List<ProductCar> GetProdcut()
		{
            return db.Table<ProductCar>().ToList();
		}
        public int UpdateProduct(ProductCar product)
		{
			return db.Update(product);
		}
        public int DeleteProduct(ProductCar product)
		{
			return db.Delete(product);
		}
    }
}
