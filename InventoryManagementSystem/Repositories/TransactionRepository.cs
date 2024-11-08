using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Repositories
{
    internal class TransactionRepository
    {
        private InventoryContext _inventoryContext;

        public TransactionRepository()
        {
            _inventoryContext = new InventoryContext();
        }
        public void Add(Transaction transaction)
        {
            _inventoryContext.Transactions.Add(transaction);
            _inventoryContext.SaveChanges();
        }

        public Transaction GetById(int id)
        {
            return _inventoryContext.Transactions.FirstOrDefault(t => t.TransactionId == id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _inventoryContext.Transactions.ToList();
        }
      
    }
}

