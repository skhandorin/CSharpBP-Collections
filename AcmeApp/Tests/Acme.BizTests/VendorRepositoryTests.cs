using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorRepositoryTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            var repository = new VendorRepository();
            var expected = 42;

            var actual = repository.RetrieveValue<int>("Select ...", 42);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveValueStringTest()
        {
            var repository = new VendorRepository();
            var expected = "test";

            var actual = repository.RetrieveValue<string>("Select ...", "test");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void RetrieveValueObjectTest()
        {
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            var actual = repository.RetrieveValue<Vendor>("Select ...", vendor);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" });
            expected.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" });

            var actual = repository.Retrieve();

            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveWithIteratorTest()
        {
            var repository = new VendorRepository();
            var expected = new List<Vendor>() {
                new Vendor() { VendorId = 1, CompanyName = "ABC Corp", Email = "abc@abc.com" },
                new Vendor() { VendorId = 2, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" }
            };

            var vendorIterator = repository.RetrieveWithIterator();
            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }
            var actual = vendorIterator.ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveAllTest()
        {
            var repository = new VendorRepository();
            var expected = new List<Vendor>() {
                { new Vendor() { VendorId = 22, CompanyName = "Amalgamated Toys", Email = "a@abc.com" } },
                { new Vendor() { VendorId = 35, CompanyName = "Car Toys", Email = "car@abc.com" } },
                { new Vendor() { VendorId = 28, CompanyName = "Toy Blocks Inc", Email = "blocks@abc.com" } },
                { new Vendor() { VendorId = 42, CompanyName = "Toys for Fun", Email = "fun@abc.com" } }
            };

            var vendors = repository.RetrieveAll();

            //var vendorQuery = from v in vendors
            //                  where v.CompanyName.Contains("Toy")
            //                  orderby v.CompanyName
            //                  select v;

            //var vendorQuery = vendors.Where(FilterCompanies)
            //                         .OrderBy(OrderCompaniesByName);

            var vendorQuery = vendors.Where(v => v.CompanyName.Contains("Toy"))
                                     .OrderBy(v => v.CompanyName);

            CollectionAssert.AreEqual(expected, vendorQuery.ToList());

        }

        //private bool FilterCompanies(Vendor v) => 
        //    v.CompanyName.Contains("Toy");

        //private string OrderCompaniesByName(Vendor v) => v.CompanyName;
    }
}