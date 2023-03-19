using AAA_ASP.net_core_web_API.DatabaseContext;
using AAA_ASP.net_core_web_API.Model;
using System.IO;
using Ganss.Excel;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

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
            //Serialization Testing
           /* FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if(File.Exists(@".\AAA"))
            {
                File.Delete("AAA");
            }
            fileStream = File.Create(@".\AAA");
            binaryFormatter.Serialize(fileStream, laptop);
            fileStream.Close();*/
           //--------------------------------------------------------------------------------------------
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

        public int DeletingLaptop(int laptopId)
        {
            Laptop obj = _connection.Laptop.FirstOrDefault(i => i.LaptopID == laptopId);
            if(obj != null)
            {
                _connection.Remove(obj);
                _connection.SaveChanges();
                return 1;
            }
            return 0;
            throw new System.NotImplementedException();
        }

        public Laptop GettingLaptop(int laptopId)
        {
            //Deserialization Testing
           /* FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Laptop laptop = null;
            if (File.Exists(@".\AAA"))                                
            {
                fileStream = File.OpenRead(@".\AAA");
                laptop = binaryFormatter.Deserialize(fileStream) as Laptop;
            }
            return laptop;*/

            Laptop obj =null ;
            obj= _connection.Laptop.FirstOrDefault(i => i.LaptopID == laptopId);
            return obj;
        }

        public string SaveToExcel()
        {
            var laptopList = _connection.Laptop.ToList();//sql Laptop table ko List me change
            ExcelMapper mapper = new ExcelMapper();
            var LaptopFile = @".\LaptopList.xlsx";
            mapper.Save(LaptopFile, laptopList, "LaptopsReport", true);
            return "Laptops List saved To Excel";

        }

        public string UpdateLaptop(Laptop laptop)
        {
            var obj = _connection.Laptop.FirstOrDefault(i => i.LaptopID == laptop.LaptopID);
            if (obj != null)
            {
                obj.LaptopName = laptop.LaptopName;
                obj.LaptopDescription= laptop.LaptopDescription;
                obj.LaptopModel = laptop.LaptopModel;

                _connection.SaveChanges();
                return "The Laptop  has been updated in Database";
            }
            else
                return "LaptopId is not present";
        }
    }
}
