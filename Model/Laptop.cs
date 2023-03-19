using System;
using System.ComponentModel.DataAnnotations;

namespace AAA_ASP.net_core_web_API.Model
{
    [Serializable]
    public class Laptop
    {
        [Key]
        public int LaptopID { get; set; }
        public string LaptopName { get; set; }
        public string LaptopDescription { get; set; }
        public int LaptopModel { get; set; }
    }
}
