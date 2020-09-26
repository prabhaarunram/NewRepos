using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopping.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shopping.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : Controller
    {
        //GET: api/<ProductController>
        [HttpGet("Products")]
        public IEnumerable<Product> Get()
        {
            CoreDbContext objCore = new CoreDbContext();
            return objCore.Product.AsEnumerable();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            try
            {
                CoreDbContext objCore = new CoreDbContext();
                return objCore.Product.Where(x => x.ProductId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Product objProduct)
        {
            try
            {
                CoreDbContext objCore = new CoreDbContext();
                //objCore.Product.Attach(objProduct);
                objCore.Entry(objProduct).State = (Microsoft.EntityFrameworkCore.EntityState)DataRowState.Added;
                objCore.SaveChanges();
                objCore.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product objProduct)
        {
            try
            {
                CoreDbContext objCore = new CoreDbContext();
                Product objUpdateProduct = new Product();
                objUpdateProduct = objCore.Product.Where(x => x.ProductId == id).FirstOrDefault();
                objUpdateProduct.ProductName = objProduct.ProductName;
                objUpdateProduct.Description = objProduct.Description;
                objUpdateProduct.Price = objProduct.Price;
                objUpdateProduct.TotalQuantity = objProduct.TotalQuantity;
                objCore.Product.Update(objUpdateProduct);
                objCore.SaveChanges();
                objCore.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                CoreDbContext objCore = new CoreDbContext();
                Product objProduct = new Product();
                objProduct = objCore.Product.Where(x => x.ProductId == id).FirstOrDefault();
                if (objProduct != null)
                {
                    objCore.Entry(objProduct).State = (Microsoft.EntityFrameworkCore.EntityState)DataRowState.Detached;
                    objCore.Product.Remove(objProduct);
                    objCore.SaveChanges();
                }

                objCore.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
