using EntityEklemeAlgoritma.Models;
using System;

namespace EntityEklemeAlgoritma
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            #region Deneme nesneleri
            Category entity1 = new Category()
            {
                Id = 1,
                Name = "Category 1",
            };

            Product entity2 = new Product()
            {
                Id = 3,
                Name = "Product 1",
                Description = "description of Product 1",
                Category = new Category()
            };
            #endregion


            MyDbContext db = new MyDbContext();

            db.AddEntityToDatabase(entity1);
            db.AddEntityToDatabase(entity2);


            Console.Read();

        }
    }
}
