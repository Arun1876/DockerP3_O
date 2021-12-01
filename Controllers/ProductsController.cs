using API_Work_DOCKER.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Work_DOCKER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : Controller
    {
       
        private static List<Product> data_p = new List<Product>()
        {
            new Product{ID =1,Name="iPhone11",cost=62000},
             new Product{ID =2,Name="iPhone12",cost=72000},
              new Product{ID =3,Name="iPhone13",cost=82000},
        };


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return data_p;
        }


        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return data_p.Find(id1 => id1.ID == id);
        }


        [HttpPost]
        public void Post(Product item)
        {
            data_p.Add(item);
        }


        [HttpPut("{id}")]
        public void Put(Product item)
        {
            int index = data_p.FindIndex(p => p.ID == item.ID);
            if (index > 0)
            {
                data_p.RemoveAt(index);
                data_p.Add(item);
            }

        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int index = data_p.FindIndex(p => p.ID == id);
            data_p.RemoveAt(index);
        }
    }
}
