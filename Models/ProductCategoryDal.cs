using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAngularApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace FinalAngularApp.Models
{
  public class ProductCategoryDAL
  {
    string ConnectionString = "Data Source=localhost;Initial Catalog=TestDeepa;Integrated Security=True";

    SqlConnection conn;
    public ProductCategoryDAL()
    {
      conn = new SqlConnection(ConnectionString);
      conn.Open();
    }
    public ProductCategory GetCategory(int Category_Id)
    {
      SqlDataReader srd;
      SqlCommand cmd = new SqlCommand("select * from Product_Category where Category_Id=" + Category_Id, conn);
      srd = cmd.ExecuteReader();
      srd.Read();
      List<ProductCategory> lstCategory = new List<ProductCategory>();

      ProductCategory category = new ProductCategory();
      category.Category_ID = Convert.ToInt32(srd["Category_ID"]);
      category.Category_Name = srd["Category_Name"].ToString();
      

      return category;

    }
    public IEnumerable<ProductCategory> GetAllProductsCategory()
    {
      SqlDataReader srd;
      SqlCommand cmd = new SqlCommand("select * from Product_Category", conn);
      srd = cmd.ExecuteReader();

      List<ProductCategory> lstproductcategory = new List<ProductCategory>();
      while (srd.Read())
      {
        ProductCategory category = new ProductCategory();
        category.Category_ID = Convert.ToInt32(srd["Category_ID"]);
        category.Category_Name = srd["Category_Name"].ToString();

        lstproductcategory.Add(category);
      }
      return lstproductcategory;

    }

    public int AddProductCategory(ProductCategory objCategory)
    {

      SqlCommand cmd = new SqlCommand("insert into Product_Category values(" + objCategory.Category_ID + ",'" + objCategory.Category_Name + "')", conn);
      return cmd.ExecuteNonQuery();

    }

    public int DeleteProductCategory(int Category_ID)
    {

      SqlCommand cmd = new SqlCommand("delete from Product_Category where Category_ID=" + Category_ID, conn);
      return cmd.ExecuteNonQuery();

    }
    public int UpdateProductCategory(ProductCategory objProductcategory)
    {

      SqlCommand cmd = new SqlCommand("update Product_Category set Category_Name='" + objProductcategory.Category_Name + "' where Category_ID=" + objProductcategory.Category_ID, conn);
      return cmd.ExecuteNonQuery();

    }
  }
}
