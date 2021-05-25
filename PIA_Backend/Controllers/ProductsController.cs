using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PIA_Backend.Backend;
using PIA_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PIA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        //IActionResult salio de https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-5.0
        public IActionResult Get()
        {
            return Ok(new ProductService().GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new ProductService().GetProductByID(id));
        }

        [HttpPost]
        public void Post([FromBody] ProductModel newProduct)
        {
            new ProductService().AddNewProduct(newProduct);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductModel modifiedProduct)
        {
            new ProductService().UpdateProduct(id, modifiedProduct);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ProductService().DeleteProduct(id);
        }
    }
}
