﻿using AAA_ASP.net_core_web_API.Model;

namespace AAA_ASP.net_core_web_API.Core
{
    public interface ILaptop
    {
        public string AddingLaptop(Laptop laptop);
        public int DeletingLaptop(int laptopId);
        public string UpdateLaptop(Laptop laptop);  
        public Laptop GettingLaptop(int laptopId);
        public string SaveToExcel();

    }
}
