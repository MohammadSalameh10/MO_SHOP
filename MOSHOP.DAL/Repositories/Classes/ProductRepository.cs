using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOSHOP.DAL.Data;
using MOSHOP.DAL.Models;
using MOSHOP.DAL.Repositories.Interfaces;

namespace MOSHOP.DAL.Repositories.Classes
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
