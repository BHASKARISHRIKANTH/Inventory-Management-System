using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Repositories
{

    internal class InventoryRepository
    {
        private InventoryContext _inventorycontext;

        public InventoryRepository()
        {
            _inventorycontext = new InventoryContext();
        }

        public void Add(Inventory inventory)
        {
            _inventorycontext.Inventories.Add(inventory);
            _inventorycontext.SaveChanges();
        }

        public void Update(Inventory inventory)
        {
            _inventorycontext.Inventories.Update(inventory);
            _inventorycontext.SaveChanges();
        }

        public Inventory GetByProductId(int productId)
        {
            return _inventorycontext.Inventories.FirstOrDefault(i => i.Id == productId);
        }

        public List<Inventory> GetAll()
        {
            var inventoryList = _inventorycontext.Inventories.ToList();
            return inventoryList;

        }

        public List<Inventory> ShowInventory()
        {
            var list = _inventorycontext.Inventories
        
        .Include(inventory => inventory.Products)  
            .Include(product => product.Suppliers) 
        .Include(inventory => inventory.Transactions)  
        .ToList(); 

            return list;


           
        }
        
       
    }
}
