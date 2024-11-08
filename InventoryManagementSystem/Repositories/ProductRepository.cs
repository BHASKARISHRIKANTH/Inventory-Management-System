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
    internal class ProductRepository
    {
        private InventoryContext _inventoryContext;

        public ProductRepository()
        {
            _inventoryContext = new InventoryContext();
        }
        public List<Product> GetAll()
        {
            var productsList = _inventoryContext.Products.ToList();
            return productsList;
        }
        public Product GetById(int id)
        {
            var product = _inventoryContext.Products.FirstOrDefault(dept => dept.Id == id);
            if (product != null)
                return product;
            throw new Exception("No such product exists");
        }
        
        public void Update(Product product)
        {
            _inventoryContext.Entry(product).State = EntityState.Modified;
            _inventoryContext.SaveChanges();
        }
       
        public Product GetProduct(int id)
        {
            var product = _inventoryContext.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new InvalidProductIdException("Product with the specified ID does not exist.");
            }
            return product;
        }

        public void Add(Product product)
        {
            if (_inventoryContext.Products.Any(p => p.Name == product.Name))
            {
                throw new DuplicateProductException("A product with this name already exists.");
            }
            _inventoryContext.Products.Add(product);
            _inventoryContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            if (product == null)
            {
                throw new InvalidProductIdException("Product with the specified ID does not exist.");
            }
            _inventoryContext.Products.Remove(product);
            _inventoryContext.SaveChanges();
        }

        public void AdjustStock(int productId, int quantity)
        {
            var product = GetProduct(productId);

            if (quantity < 0 && product.Quantity < Math.Abs(quantity))
            {
                throw new InsufficientStockException("Not enough stock available for this operation.");
            }

            product.Quantity += quantity;
            _inventoryContext.SaveChanges();
        }
    }

}
