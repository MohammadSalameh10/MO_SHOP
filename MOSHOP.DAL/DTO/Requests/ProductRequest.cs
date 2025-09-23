using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MOSHOP.DAL.Models;

namespace MOSHOP.DAL.DTO.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public IFormFile MainImage { get; set; }

        public List<IFormFile> SubImages { get; set; }
        public double Rate { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
