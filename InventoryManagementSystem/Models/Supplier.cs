using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public Inventory Inventory { get; set; }

        [ForeignKey("Inventory")]
        
        public int? InventoryId { get; set; }

        public override string ToString()
        {
            return $"SupplierId:{SupplierId}\n" +
            $"Name:{Name}\n" +
            $"ContactInfo:{ContactInfo}\n" +
            $"InventoryId:{InventoryId}\n";
            

        }
    }
}
