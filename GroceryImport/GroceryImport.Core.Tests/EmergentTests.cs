using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GroceryImport.Core.Tests
{
    [TestClass]
    public class EmergentTests
    {
        [TestMethod]
        public void ProvideNoRecordsForEmptyInputData()
        {
            IProductRecordCollection productRecordCollection = new CompanyStoreProductRecordCollection(new InMemoryInputData());

            List<ProductRecord> productRecords = productRecordCollection.ToList();
            productRecords.Should().BeEmpty();
        }
    }

    public sealed class CompanyStoreProductRecordCollection : IProductRecordCollection
    {
        private readonly IInputData _inputData;

        public CompanyStoreProductRecordCollection(IInputData inputData) => _inputData = inputData;



        public IEnumerator<ProductRecord> GetEnumerator()
        {
            return new List<ProductRecord>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public interface IProductRecordCollection : IEnumerable<ProductRecord>
    {
    }

    public sealed class ProductRecord
    {
    }

    public sealed class InMemoryInputData : IInputData
    {
    }

    public interface IInputData
    {
    }
}
