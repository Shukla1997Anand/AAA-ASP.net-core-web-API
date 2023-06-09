﻿using AAA_ASP.net_core_web_API.Core;
using AAA_ASP.net_core_web_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AAA_ASP.net_core_web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private ILaptop _laptop;

        public LaptopController(ILaptop laptop)
        {
            _laptop = laptop;
        }
        [HttpPost]
        public string AddLaptop(Laptop laptop)
        {
            return _laptop.AddingLaptop(laptop);
        }

        [HttpGet]

        public Laptop GetLaptop(int laptopId)
        {
            return _laptop.GettingLaptop(laptopId);
        }

        [HttpPut]

        public string UpdatedLaptopDetails(Laptop laptop)
        {
            return _laptop.UpdateLaptop(laptop);
        }
        [HttpDelete]
        public int DeleteLaptop(int LaptopId)
        {
            return _laptop.DeletingLaptop(LaptopId);
        }
        [Route("api/Excel")]
        [HttpGet]
        public string ExportToExcel()
        {
            return _laptop.SaveToExcel();
            
        }
    }

}
