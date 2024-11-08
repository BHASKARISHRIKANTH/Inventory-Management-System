using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Presentation
{
    internal class Menu
    {
        private ProductRepository productRepository = new ProductRepository();

        private SupplierRepository supplierRepository = new SupplierRepository();
        private TransactionRepository transactionRepository = new TransactionRepository();
        private InventoryRepository inventoryRepository = new InventoryRepository();


        public void DisplayMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nWelcome to the Inventory Management System");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Supplier Management");
                Console.WriteLine("3. Transaction Management");
                Console.WriteLine("4. Generate Report");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayProductMenu();
                            break;
                        case 2:
                            DisplaySupplierMenu();
                            break;
                        case 3:
                            DisplayTransactionMenu();
                            break;
                        case 4:
                            GenerateReport();
                            break;
                        case 5:
                            exit = true;
                            Console.WriteLine("Exiting the Inventory Management System. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        


        private void DisplayProductMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\nProduct Management");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View Product's Details");
                Console.WriteLine("5. View All Products");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddProduct();
                            break;
                        case 2:
                            UpdateProduct();
                            break;
                        case 3:
                            DeleteProduct();
                            break;
                        case 4:
                            ViewProductDetails();
                            break;
                        case 5:
                            ViewAllProducts();
                            break;
                        case 6:
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        private void AddProduct()
        {
            try
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Product Price: ");
                double price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Product product = new Product { Name = name, Price = price, Quantity = quantity };
                productRepository.Add(product);
                Console.WriteLine("Product added successfully.");
            }
            catch (DuplicateProductException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void UpdateProduct()
        {
            Console.Write("Enter Product ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var product = productRepository.GetById(id);

            if (product != null)
            {
                Console.Write("Enter new Product Name: ");
                product.Name = Console.ReadLine();
                Console.Write("Enter new Product Price: ");
                product.Price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter new Quantity: ");
                product.Quantity = Convert.ToInt32(Console.ReadLine());

                productRepository.Update(product);
                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        private void DeleteProduct()
        {
            try
            {
                Console.Write("Enter Product ID to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());


                var product = productRepository.GetById(id);


                if (product != null)
                {
                    productRepository.Delete(product);
                    Console.WriteLine("Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (InvalidProductIdException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        private void ViewProductDetails()
        {
            Console.Write("Enter Product ID to view: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var product = productRepository.GetById(id);

            if (product != null)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        private void ViewAllProducts()
        {
            var products = productRepository.GetAll();
            Console.WriteLine("Product List:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }

        private void DisplaySupplierMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\nSupplier Management");
                Console.WriteLine("1. Add Supplier");
                Console.WriteLine("2. Update Supplier");
                Console.WriteLine("3. Delete Supplier");
                Console.WriteLine("4. View Supplier's Details");
                Console.WriteLine("5. View All Suppliers");
                Console.WriteLine("6. Go Back to Main Menu");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddSupplier();
                            break;
                        case 2:
                            UpdateSupplier();
                            break;
                        case 3:
                            DeleteSupplier();
                            break;
                        case 4:
                            ViewSupplierDetails();
                            break;
                        case 5:
                            ViewAllSuppliers();
                            break;
                        case 6:
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private void AddSupplier()
        {
            Console.Write("Enter Supplier Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Supplier Contact: ");
            string contact = Console.ReadLine();

            Supplier supplier = new Supplier { Name = name, ContactInfo = contact };
            supplierRepository.Add(supplier);
            Console.WriteLine("Supplier added successfully.");
        }

        private void UpdateSupplier()
        {
            Console.Write("Enter Supplier ID to update: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var supplier = supplierRepository.GetById(id);

            if (supplier != null)
            {
                Console.Write("Enter new Supplier Name: ");
                supplier.Name = Console.ReadLine();
                Console.Write("Enter new Supplier Contact: ");
                supplier.ContactInfo = Console.ReadLine();

                supplierRepository.Update(supplier);
                Console.WriteLine("Supplier updated successfully.");
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        private void DeleteSupplier()
        {
            Console.Write("Enter Supplier ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var supplier = supplierRepository.GetById(id);
            if (supplier != null)
            {
                supplierRepository.Delete(supplier);
                Console.WriteLine("supplier deleted successfully");
            }
            else
            {
                Console.WriteLine("supplier not found");
            }
        }

        private void ViewSupplierDetails()
        {
            Console.Write("Enter Supplier ID to view: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var supplier = supplierRepository.GetById(id);

            if (supplier != null)
            {
                Console.WriteLine($"Supplier ID: {supplier.SupplierId}, Name: {supplier.Name}, Contact: {supplier.ContactInfo}");
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        private void ViewAllSuppliers()
        {
            var suppliers = supplierRepository.GetAll();
            Console.WriteLine("Supplier List:");
            foreach (var supplier in suppliers)
            {
                Console.WriteLine($"ID: {supplier.SupplierId}, Name: {supplier.Name}, Contact: {supplier.ContactInfo}");
            }
        }


        private void DisplayTransactionMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\nTransaction Management");
                Console.WriteLine("1. Add Stock");
                Console.WriteLine("2. Remove Stock");
                Console.WriteLine("3. View Transaction History");
                Console.WriteLine("4. Go Back to Main Menu");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddStock();
                            break;
                        case 2:
                            RemoveStock();
                            break;
                        case 3:
                            ViewTransactionHistory();
                            break;
                        case 4:
                            back = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private void AddStock()
        {
            Console.Write("Enter Product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Quantity to Add: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            var product = productRepository.GetById(productId);
            if (product != null)
            {
                product.Quantity += quantity;
                productRepository.Update(product);

                var transaction = new Transaction
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Type = "Add",
                    Date = DateTime.Now
                };
                transactionRepository.Add(transaction);

                Console.WriteLine("Stock added successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        private void RemoveStock()
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int productId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Quantity to Remove: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                var product = productRepository.GetById(productId);
                if (product != null && product.Quantity >= quantity)
                {
                    product.Quantity -= quantity;
                    productRepository.Update(product);

                    var transaction = new Transaction
                    {
                        ProductId = productId,
                        Quantity = -quantity,
                        Type = "Remove",
                        Date = DateTime.Now
                    };
                    transactionRepository.Add(transaction);

                    Console.WriteLine("Stock removed successfully.");
                }
            }
            catch (InsufficientStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidProductIdException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
           
        

        private void ViewTransactionHistory()
        {
            var transactions = transactionRepository.GetAll();
            Console.WriteLine("Transaction History:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Product ID: {transaction.ProductId}, Type: {transaction.Type}, Quantity: {transaction.Quantity}, Date: {transaction.Date}");
            }
        }

        private static void GenerateReport()
        {
            InventoryRepository inventoryRepository = new InventoryRepository();
            TransactionRepository transactionRepository = new TransactionRepository();
            SupplierRepository supplierRepository = new SupplierRepository();
            ProductRepository productRepository = new ProductRepository();
            bool continueInventory = true;
            while (continueInventory)
            {
                Console.WriteLine("Generate Report:");
                Console.WriteLine("1. Inventory Details");
                Console.WriteLine("2. List Products");
                Console.WriteLine("3. List Suppliers");
                Console.WriteLine("4. List Transactions");
                Console.WriteLine("5. Go Back to Main Menu");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        GenerateInventoryDetails(inventoryRepository);
                        break;
                    case 2:
                        ListProducts(productRepository);
                        break;
                    case 3:
                        ListSuppliers(supplierRepository);
                        break;
                    case 4:
                        ListTransactions(transactionRepository);
                        break;
                    case 5:
                        continueInventory = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
            static void GenerateInventoryDetails(InventoryRepository inventoryRepository)
            {
                var inventoryList = inventoryRepository.ShowInventory();
                inventoryList.ForEach(inventory =>
                {
                    Console.WriteLine(inventory);
                    Console.WriteLine();
                    inventory.Products.ForEach(product =>
                    {
                        Console.WriteLine(product);

                        Console.WriteLine();
                    });

                    inventory.Suppliers.ForEach(supplier =>
                    {
                        Console.WriteLine(supplier);
                        Console.WriteLine();

                    });

                    inventory.Transactions.ForEach(transaction =>
                    {
                        Console.WriteLine(transaction);
                        Console.WriteLine();
                    });

                    Console.WriteLine("================================================");
                });

            }
            static void ListProducts(ProductRepository productRepository)
            {
                var products = productRepository.GetAll();
                Console.WriteLine("-------- List of Products --------");
                if (products.Count == 0)
                {
                    Console.WriteLine("No products available.");
                }
                else
                {
                    foreach (var product in products)
                    {
                        Console.WriteLine(product);
                        Console.WriteLine("================================");
                    }
                }
            }


            static void ListSuppliers(SupplierRepository supplierRepository)
            {
                var suppliers = supplierRepository.GetAll();
                Console.WriteLine("-------- List of Suppliers --------");
                if (suppliers.Count == 0)
                {
                    Console.WriteLine("No suppliers available.");
                }
                else
                {
                    foreach (var supplier in suppliers)
                    {
                        Console.WriteLine(supplier);
                        Console.WriteLine("================================");
                    }
                }
            }


            static void ListTransactions(TransactionRepository transactionRepository)
            {
                var transactions = transactionRepository.GetAll();
                Console.WriteLine("-------- List of Transactions --------");
               
                    foreach (var transaction in transactions)
                    {
                        Console.WriteLine(transaction);
                        Console.WriteLine("================================");
                    }
                
            }
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }



       
        
    }
}
