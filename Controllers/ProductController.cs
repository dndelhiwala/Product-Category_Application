using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalAngularApp.Models;

namespace FinalAngularApp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {

    ProductDAL objProductDal = new ProductDAL();
    // GET api/values
    [HttpGet]
    public IEnumerable<Product> GetAllProducts()
    {
      return objProductDal.GetAllProducts();
    }

    // GET api/values/5
    [HttpGet("{Product_ID}")]
    public Product GetProduct(int Product_ID)
    {
      return objProductDal.GetProduct(Product_ID);
    }

    // POST api/values
    [HttpPost]
    public int AddProduct(Product objProduct)
    {
      return objProductDal.AddProducts(objProduct);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public int UpdateProduct(int id, Product objProduct)
    {
      return objProductDal.UpdateProducts(objProduct);
    }

    // DELETE api/values/5
    [HttpDelete("{Product_Id}")]
    public int DeleteProduct(int Product_Id)
    {
      return objProductDal.DeleteProducts(Product_Id);
    }
  }
}
