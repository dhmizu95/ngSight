using System;
using System.Collections.Generic;
using System.Linq;
using ngSightAPI.Models;

namespace ngSightAPI.Helpers
{
    public class DataSeed
    {
        private readonly ApiContext _context;

        public DataSeed(ApiContext context)
        {
            _context = context;
        }

        public void SeedData(int nCustomers, int nOrders)
        {
            if (!_context.Customers.Any())
            {
                SeedCustomers(nCustomers);
                _context.SaveChanges();
            }

            if (!_context.Orders.Any())
            {
                SeedOrders(nOrders);
                _context.SaveChanges();
            }

            if (!_context.Servers.Any())
            {
                SeedServers();
                _context.SaveChanges();
            }
        }

        private List<Customer> BuildCustomerList(int nCustomers)
        {
            var customers = new List<Customer>();
            var names = new List<string>();

            for (var i = 1; i <= nCustomers; i++)
            {
                var name = SeedHelper.MakeUniqueCustomerName(names);
                names.Add(name);

                customers.Add(new Customer
                {
                    Id = i,
                    Name = name,
                    Email = SeedHelper.MakeCustomerEmail(name),
                    State = SeedHelper.GetRandomState()
                });
            }

            return customers;
        }

        private void SeedCustomers(int nCustomers)
        {
            var customers = BuildCustomerList(nCustomers);

            foreach (var customer in customers)
            {
                _context.Customers.Add(customer);
            }
        }

        private List<Order> BuildOrderList(int nOrders)
        {
            var orders = new List<Order>();
            var random = new Random();

            for (var i = 1; i <= nOrders; i++)
            {
                var randomCustomerId = random.Next(1, _context.Customers.Count());
                var placed = SeedHelper.GetRandomOrderPlaced();
                var completed = SeedHelper.GetRandomOrderCompleted(placed);

                orders.Add(new Order
                {
                    Id = i,
                    Customer = _context.Customers.First(c => c.Id == randomCustomerId),
                    Total = SeedHelper.GetRandomTotal(),
                    Placed = placed,
                    Completed = completed
                });
            }

            return orders;
        }

        private void SeedOrders(int nOrders)
        {
            var orders = BuildOrderList(nOrders);

            foreach (var order in orders)
            {
                _context.Orders.Add(order);
            }
        }

        private void SeedServers()
        {
            var servers = BuildServerList();

            foreach (var server in servers)
            {
                _context.Servers.Add(server);
            }
        }

        private List<Server> BuildServerList()
        {
            return new List<Server>
            {
                new Server
                {
                    Id = 1,
                    Name = "Dev-Web",
                    IsOnline = false
                },
                new Server
                {
                    Id = 2,
                    Name = "Dev-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Id = 3,
                    Name = "Dev-Services",
                    IsOnline = false
                },
                new Server
                {
                    Id = 4,
                    Name = "QA-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id = 5,
                    Name = "QA-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Id = 6,
                    Name = "QA-Services",
                    IsOnline = true
                },
                new Server
                {
                    Id = 7,
                    Name = "Prod-Web",
                    IsOnline = false
                },
                new Server
                {
                    Id = 8,
                    Name = "Prod-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Id = 9,
                    Name = "Prod-Services",
                    IsOnline = false
                }
            };
        }
    }
}