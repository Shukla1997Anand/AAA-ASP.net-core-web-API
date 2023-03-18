using AAA_ASP.net_core_web_API.DatabaseContext;
using AAA_ASP.net_core_web_API.Model;
using System.Linq;

namespace AAA_ASP.net_core_web_API.Core
{
    public class LaptopRepository : ILaptop
    {
        private DatabaseConnection _connection;//database baat kare ga

        public LaptopRepository(DatabaseConnection connection)
        {
            this._connection = connection;
        }

        public string AddingLaptop(Laptop laptop)
        {
            var obj=_connection.Laptop.FirstOrDefault(i=>i.LaptopID==laptop.LaptopID);//lamda fun C#
            if (obj == null)
            {
                _connection.Laptop.Add(laptop);//database--> table -->add
                _connection.SaveChanges();
                return "The Laptop Has been added in Database";
            }
            else
            {
                return  "The Laptop Id Already Existed";
            }
        }

        public string DeleteLaptop(int laptopId)
        {
            throw new System.NotImplementedException();
        }

        public Laptop GetLaptop(int laptopId)
        {
            throw new System.NotImplementedException();
        }

        public string UpdateLaptop(Laptop laptop)
        {
            throw new System.NotImplementedException();
        }
    }
}
