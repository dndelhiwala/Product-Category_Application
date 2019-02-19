using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAngularApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace FinalAngularApp.Models
{
  public class ProductDAL
  {
    string ConnectionString= "Data Source=localhost;Initial Catalog=TestDeepa;Integrated Security=True";

    SqlConnection conn;
    public ProductDAL()
    {
      conn = new SqlConnection(ConnectionString);
      conn.Open();
    }
    public Product GetProduct(int Product_Id)
    {
      SqlDataReader srd;
      SqlCommand cmd = new SqlCommand("select *,(select Category_Name from Product_Category PC where PC.Category_ID=P.Category_ID) as Category_Name from Product P where Product_Id=" + Product_Id, conn);
      srd = cmd.ExecuteReader();
      srd.Read();
      List<Product> lstproduct = new List<Product>();
      
        Product prod = new Product();
        prod.Product_ID = Convert.ToInt32(srd["Product_ID"]);
        prod.Category_ID = Convert.ToInt32(srd["Category_ID"]);
      prod.Category_Name = Convert.ToString(srd["Category_Name"]);
      prod.Product_Name = Convert.ToString(srd["Product_Name"]);
        prod.Price = Convert.ToDouble(srd["Price"]);
        prod.SOH = Convert.ToInt32(srd["SOH"]);

      return prod;

    }
    public IEnumerable<Product> GetAllProducts()
    {
      SqlDataReader srd;
      SqlCommand cmd = new SqlCommand("select Product_Id,Category_Id,(select Category_Name from Product_Category PC where PC.Category_Id=P.Category_Id ) as Category_Name,Product_Name,Price,SOH from Product P", conn);
      srd = cmd.ExecuteReader();

      List<Product> lstproduct = new List<Product>();
      while(srd.Read())
      {
        Product prod = new Product();
        prod.Product_ID = Convert.ToInt32(srd["Product_ID"]);
        prod.Category_ID = Convert.ToInt32(srd["Category_ID"]);
        prod.Category_Name = Convert.ToString(srd["Category_Name"]);
        prod.Product_Name =Convert.ToString(srd["Product_Name"]);
        prod.Price =Convert.ToDouble(srd["Price"]);
        prod.SOH =Convert.ToInt32(srd["SOH"]);

        lstproduct.Add(prod);
      }
      return lstproduct;

    }

    public int AddProducts(Product objProd)
    {
      
      SqlCommand cmd = new SqlCommand("insert into Product values("+ objProd.Product_ID + "," + objProd.Category_ID + ",'" + objProd.Product_Name + "'," + objProd.Price + "," + objProd.SOH + ")", conn);
      return  cmd.ExecuteNonQuery();

    }

    public int DeleteProducts(int Product_ID)
    {

      SqlCommand cmd = new SqlCommand("delete from Product where Product_ID=" + Product_ID, conn);
      return cmd.ExecuteNonQuery();

    }
    public int UpdateProducts(Product objProduct)
    {

      SqlCommand cmd = new SqlCommand("update Product set Category_Id=" + objProduct.Category_ID + ", Product_Name='" + objProduct.Product_Name +"',Price=" + objProduct.Price +
                                      ", SOH="+ objProduct.SOH +" where Product_ID=" + objProduct.Product_ID, conn);
      return cmd.ExecuteNonQuery();

    }
  }
}
