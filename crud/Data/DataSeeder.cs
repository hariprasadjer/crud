using crud.Models;

namespace crud.Data
{
    // Seeds initial records if the database is empty
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Laptop", Price = 1000, Stock = 10 },
                    new Product { Name = "Mouse", Price = 25, Stock = 100 },
                    new Product { Name = "Keyboard", Price = 50, Stock = 50 }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                var firstProduct = context.Products.First();
                var order = new Order
                {
                    ProductId = firstProduct.ProductId,
                    Quantity = 1,
                    OrderDate = DateTime.Today
                };
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
