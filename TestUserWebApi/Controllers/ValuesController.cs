using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestUserWebApi.Models;

namespace TestUserWebApi.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values
        
        
        public List<Product> GetAllProducts()
        {
            using (var db= new denemeEntities())
            {
                return db.Product.ToList();
            }
        }

        // GET api/values/5
        
        public Product GetProduct(int id)
        {
            using (var db = new denemeEntities())
            {
                return db.Product.Find(id);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post (string name,double price,int stockquantity)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Product urun = new Product()
                {
                    productName = name,
                    stockQuantity = stockquantity,
                    UnitPrice = Convert.ToDecimal(price)
                };
                using (var db = new denemeEntities())
                {
                     db.Product.Add(urun);
                    db.SaveChanges();
                }

            }
           
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, string name, double price, int stockquantity)
        {
            if (!string.IsNullOrEmpty(name))
            {   
                using (var db = new denemeEntities())
                {
                    Product urun = db.Product.Find(id);
                    urun.productName = name;
                    urun.stockQuantity = stockquantity;
                    urun.UnitPrice = Convert.ToDecimal(price);

                    db.Entry(urun).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

            }
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            
                using (var db = new denemeEntities())
                {
                    Product urun = db.Product.Find(id);
                    db.Entry(urun).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }

            
        }
    }
}
