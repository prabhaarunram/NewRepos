using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shopping.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : Controller
    {
        // GET: api/<OrderController>
        [HttpGet("Orders")]
        public IEnumerable<Order> Get()
        {
            CoreDbContext objCore = new CoreDbContext();
            return objCore.Order.AsEnumerable();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            CoreDbContext objCore = new CoreDbContext();
            return objCore.Order.Where(x => x.OrderId == id).FirstOrDefault();
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] Order objOrder)
        {
            CoreDbContext objCore = new CoreDbContext();
            objCore.Order.Attach(objOrder);
            objCore.Entry(objOrder).State = (Microsoft.EntityFrameworkCore.EntityState)DataRowState.Added;
            objCore.SaveChanges();
            objCore.Dispose();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order objOrder)
        {
            CoreDbContext objCore = new CoreDbContext();
            Order objUpdateOrder = new Order();
            objUpdateOrder = objCore.Order.Where(x => x.OrderId == id).FirstOrDefault();
            objUpdateOrder.Quantity = objOrder.Quantity;
            objCore.Order.Update(objUpdateOrder);
            objCore.SaveChanges();
            objCore.Dispose();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CoreDbContext objCore = new CoreDbContext();
            Order objOrder = new Order();
            objOrder = objCore.Order.Where(x => x.OrderId == id).FirstOrDefault();
            objCore.Order.Remove(objOrder);
            objCore.SaveChanges();
            objCore.Dispose();
        }
    }
}
