using System;
using System.Reflection;

namespace EntityEklemeAlgoritma.Models
{
    public class MyDbContext
    {

        public MyDbContext()
        {
            // database connection logic
        }

        /// <summary>
        /// Nesneyi tabloya ekler. Tablo mevcut değilse nesnenin çoğul ismi ile yaratır.
        /// </summary>
        /// <param name="entity"></param>
        public void AddEntityToDatabase(IEntity entity)
        {

            Type t = entity.GetType();

            // tablo yarat
            CreateTable(t.Name, t.GetProperties());
            Console.WriteLine("");
            AddValuesToTable(entity);
            Console.WriteLine("-------------------------------------------------\n");



        }

        /// <summary>
        /// Tablo oluşturur.
        /// </summary>
        /// <param name="tableName">Tablo ismi</param>
        /// <param name="columns">Sütunlar</param>
        /// <returns>Tablo yaratıldıysa true, yaratılamadıysa false döndürür.</returns>
        private bool CreateTable(string tableName, PropertyInfo[] columns)
        {
            // tablo var mı kontrol et yoksa yarat
            if (true)
            {
                Console.WriteLine("'" + tableName.ToUpper() + "S" + "' table is created");

                foreach (var column in columns)
                {

                    CreateColumn(column);

                }

            }
            else
            {
                // error logic
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sütun yaratır.
        /// </summary>
        /// <param name="column">Sütun bilgisi</param>
        /// <returns>Sütün yaratıldıysa true, yaratılamadıysa false döndürür.</returns>
        private bool CreateColumn(PropertyInfo column)
        {
            var type = column.PropertyType;
            var name = column.Name;
            bool isColumnExists = false;

            // complex tip değilse(class) değilse 
            if (type.IsPrimitive || type == typeof(string))
            {
                // sütun databasede yoksa yarat
                if (!isColumnExists)
                {
                    Console.WriteLine("  └ {0} : '{1}' column is created", type.Name, name);
                }
                else // sütun mevcutsa hata ver
                {
                    // error logic
                }
            }
            else // complex type
            {
                // complex type içinde id ara
                Console.WriteLine("  └ {0} : Complex type. Search for an id in {0}", type.Name);
            }

            return true;
        }

        /// <summary>
        /// Değerleri var olan tabloya ekler.
        /// </summary>
        /// <param name="entity">Tabloya eklenecek nesne</param>
        private void AddValuesToTable(IEntity entity)
        {
            var tableName = entity.GetType().Name;
            var columns = entity.GetType().GetProperties();

            foreach (var column in columns)
            {
                var type = column.PropertyType;

                // basit tip ise değeri sütuna ekle
                if (type.IsPrimitive || type == typeof(string))
                {
                    var columnName = column.Name;
                    var columnValue = column.GetValue(entity, null);

                    Console.WriteLine("     '" + columnValue + "' added to " + columnName);
                }
                else // complex type için id ekle
                {
                    // complex type işlemleri
                }

            }
        }

    }
}
