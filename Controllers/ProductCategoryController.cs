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
    public class ProductCategoryController : ControllerBase
    {
    ProductCategoryDAL objProductcategoryDal = new ProductCategoryDAL();
    // GET api/values
    [HttpGet]
    public IEnumerable<ProductCategory> GetAllProductCategory()
    {
      return objProductcategoryDal.GetAllProductsCategory();
    }

    // GET api/values/5
    [HttpGet("{Category_ID}")]
    public ProductCategory GetProductCategory(int Category_ID)
    {
      return objProductcategoryDal.GetCategory(Category_ID);
    }

    // POST api/values
    [HttpPost]
    public int AddProductCategory(ProductCategory objProductcategory)
    {
      return objProductcategoryDal.AddProductCategory(objProductcategory);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public int UpdateProductCategory(int id,ProductCategory objProductcategory)
    {
      return objProductcategoryDal.UpdateProductCategory(objProductcategory);
    }

    // DELETE api/values/5
    [HttpDelete("{Category_Id}")]
    public int DeleteProductCategory(int Category_Id)
    {
      return objProductcategoryDal.DeleteProductCategory(Category_Id);
    }
  }
}
