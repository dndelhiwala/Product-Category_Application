using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAngularApp.Models
{
  public class Product
  {

    public Int32 Product_ID { get; set; }
    public Int32 Category_ID { get; set; }
    public string Category_Name { get; set; }

    public string Product_Name { get; set; }
    public double Price { get; set; }
    public Int32 SOH { get; set; }

  }
}
