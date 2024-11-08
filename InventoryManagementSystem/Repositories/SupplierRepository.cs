using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Repositories
{
    internal class SupplierRepository
    {
        private InventoryContext _inventoryContext;

        public SupplierRepository()
        {
            _inventoryContext = new InventoryContext();
        }
        public List<Supplier> GetAll()
        {
            var suppliersList = _inventoryContext.Suppliers.ToList();
            return suppliersList;
        }
        public Supplier GetById(int id)
        {
            var supplier = _inventoryContext.Suppliers.FirstOrDefault(supp => supp.SupplierId == id);
            if (supplier != null)
                return supplier;
            throw new Exception("No such supplier exists");
        }
        public void Add(Supplier supplier)
        {
            _inventoryContext.Suppliers.Add(supplier);
            _inventoryContext.SaveChanges();
        }
        public void Update(Supplier supplier)
        {
            _inventoryContext.Entry(supplier).State = EntityState.Modified;
            _inventoryContext.SaveChanges();
        }
        public void Delete(Supplier supplier)
        {
            _inventoryContext.Remove(supplier);
            _inventoryContext.SaveChanges();
        }

    }
}
