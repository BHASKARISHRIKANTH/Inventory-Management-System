using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Inventory Inventory { get; set; }
        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }


        public override string ToString()
        {
            return $"Product Id:{Id}\n" +
                $"Product Name:{Name}\n" +
                $"Product Description:{Description}\n"+
                $"Product Quantity:{Quantity}\n"+
                $"Product Price:{Price}"+
                $"InventoryId:{InventoryId}";

        }

    }
}
