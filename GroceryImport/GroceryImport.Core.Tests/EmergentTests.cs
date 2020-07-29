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
        [TestMethod, TestCategory("unit")]
        public void ProductRecord_ShouldTakeStringRecord()
        {
            //Arrange
            ProductRecord productRecord = new ProductRecord("");

            //Act

            //Assert
        }
    }

    public sealed class ProductRecord
    {
        private readonly string _record;

        public ProductRecord(string record)
        {
            _record = record;
        }
    }
}
