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

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveWithKeysTest()
        {
            var repository = new VendorRepository();
            var expected = new Dictionary<string, Vendor>()
            {
                { "ABC Corp", new Vendor(){ VendorId = 5, CompanyName = "ABC Corp", Email = "abc@abc.com" } },
                { "XYZ Inc", new Vendor() { VendorId = 8, CompanyName = "XYZ Inc", Email = "xyz@xyz.com" } }
            };

            var actual = repository.RetrieveWithKeys();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}