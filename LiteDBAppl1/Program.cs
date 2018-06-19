using LiteDB;
using System;
using System.Linq;

namespace LiteDBAppl1
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var db = new LiteDatabase(@"CustomerData.db"))
            {
                var collection = db.GetCollection<Author>("authors");
                var author = new Author
                {
                    FirstName = "Joydip",
                    LastName = "Kanjilal",
                    Address = "Hyderabad"
                };
                collection.Insert(author);
                // Get customer collection
                var customers = db.GetCollection<Customer>("customers");

                // Create your new customer instance
                var customer = new Customer
                {
                    Name = "Doe",
                    FirstName = "John",
                    Phones = new string[] { "8000-0000", "9000-0000" },
                    IsActive = true
                };

                var c2 = new Customer
                {
                    Name = "Wei",
                    FirstName = "Carl",
                    Phones = new string[] { "8000-0001", "9000-0001" },
                    IsActive = true
                };
                // Insert new customer document (Id will be auto-incremented)
                customers.Insert(customer);
                customers.Insert(c2);


                // Update a document inside a collection
                customer.FirstName = "Joana";
                customers.Update(customer);

                // Index document using a document property
                customers.EnsureIndex(x => x.Name);

                // Use Linq to query documents
                var results = customers.Find(x => x.Name.StartsWith("Do"));
                Console.WriteLine(customers.Count());
                Console.WriteLine(results.Count());
                Console.WriteLine(results.AsParallel());
                var foundAuthor = collection.FindById(1);
                Console.WriteLine(foundAuthor.FirstName + "\t" + foundAuthor.LastName);
                var FoundMaxCustomer = customers.FindById(customers.Count());
                Console.WriteLine("Latest Customer= " + FoundMaxCustomer.FirstName);
            }
        }
    }
}
