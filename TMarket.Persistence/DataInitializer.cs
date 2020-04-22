using System;
using System.Linq;
using TMarket.Persistence.DbModels;

namespace TMarket.Persistence
{
    public static class DataInitializer
    {
        public static void SeedData(this MarketDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new ProductDTO
                    {
                        Name = "პირბადე",
                        Price = 0.5M,
                        AvailableCount = 100,
                        IsAvailable = true,
                        UsefulnessTerm = new DateTime(2022, 1, 12),
                    },
                    new ProductDTO
                    {
                        Name = "საპონი",
                        Price = 2.5M,
                        AvailableCount = 120,
                        IsAvailable = true,
                        UsefulnessTerm = new DateTime(2022, 1, 12),
                    },
                    new ProductDTO
                    {
                        Name = "კორონას საწინააღმდეგო მაზი",
                        Price = 22.5M,
                        AvailableCount = 250,
                        IsAvailable = true,
                        UsefulnessTerm = new DateTime(2022, 1, 12),
                    });

                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new UserDTO { Name = "ეკა", Lastname = "ჩოგოვაძე" },
                    new UserDTO { Name = "ლადო", Lastname = "ჯიქია" },
                    new UserDTO { Name = "ირაკლი", Lastname = "ფაჩულია" }
                    );

                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new OrderDTO { UserId = 1 },
                    new OrderDTO { UserId = 2 },
                    new OrderDTO { UserId = 3 }
                    );

                context.SaveChanges();
            }

            if (!context.OrderProducts.Any())
            {
                context.OrderProducts.AddRange(
                    new OrderProductDTO { OrderId = 1, ProductId = 1, Quantity = 5},
                    new OrderProductDTO { OrderId = 1, ProductId = 2, Quantity = 10},
                    new OrderProductDTO { OrderId = 2, ProductId = 3, Quantity = 6},
                    new OrderProductDTO { OrderId = 2, ProductId = 2, Quantity = 12},
                    new OrderProductDTO { OrderId = 3, ProductId = 1, Quantity = 1},
                    new OrderProductDTO { OrderId = 3, ProductId = 2, Quantity = 2 },
                    new OrderProductDTO { OrderId = 3, ProductId = 3, Quantity = 3 }
                );

                context.SaveChanges();
            }
        }
    }
}
