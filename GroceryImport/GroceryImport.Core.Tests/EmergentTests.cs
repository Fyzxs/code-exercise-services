using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using FluentAssertions;
using FluentAssertions.Common;
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
            ProductRecordSample1 productRecord = new ProductRecordSample1("");

            //Act

            //Assert
        }

        [TestMethod, TestCategory("unit")]
        public void ProductRecord_ShouldReturnProductId()
        {
            //Arrange
            ProductRecordSample1 productRecord = new ProductRecordSample1("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            string actual = productRecord.ProductId();

            //Assert
            actual.Should().Be("14963801");
        }
        [TestMethod, TestCategory("unit")]
        public void ProductRecord_ShouldReturnProductId_FromProductSample4()
        {
            //Arrange
            ProductRecordSample4 productRecord = new ProductRecordSample4("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            string actual = productRecord.Get("ProductId");

            //Assert
            actual.Should().Be("14963801");
        }
    }

    public sealed class ProductRecordSample1
    {
        private readonly string _record;

        public ProductRecordSample1(string record) => _record = record;



        public string ProductId()
        {
            return _record.Substring(0, 8);
        }
    }

    public sealed class ProductRecordSample2
    {
        private readonly string _record;

        private Dictionary<string, Func<string, string>> _map = new Dictionary<string, Func<string, string>>
        {
            {"ProductId", x => x.Substring(0, 8)}
        };

        public ProductRecordSample2(string record) => _record = record;


        public string Get(string key)
        {
            return _map[key](_record);
        }
    }

    public sealed partial class ProductRecordSample4
    {
        private readonly string _record;

        private static readonly RecordFieldCollection Collection = new RecordFieldCollection
        {
            new ProductId()
        };

        public ProductRecordSample4(string record) => _record = record;

        public string Get(string key)
        {
            return Collection[key].Value(_record);
        }


        public sealed class RecordFieldCollection : IEnumerable<IField>
        {
            private readonly Dictionary<string, IField> _map = new Dictionary<string, IField>();

            public void Add(IField field) => _map.Add(field.FieldKey(), field);

            public IField this[string key] => _map[key];

            public IEnumerator<IField> GetEnumerator() => _map.Values.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        public sealed class ProductId : IField
        {
            public string Value(string record) => record.Substring(0, 8);

            public string FieldKey() => "ProductId";
        }

        public interface IField
        {
            public string Value(string record);
            string FieldKey();
        }
    }


    //public sealed class ProductRecordSample3
    //{
    //    private readonly string _record;

    //    private readonly List<IField> _fields = new List<IField>
    //    {
    //        new ProductId()
    //    };

    //    public ProductRecordSample3(string record) => _record = record;

    //    public string Get(string key) => _fields.First(x => x.Is).Value(_record);

    //    private class ProductId : IField
    //    {
    //        public string Value(string record) => record.Substring(0, 8);
    //    }

    //    internal interface IField
    //    {
    //        public string Value(string record);
    //    }
    //}

}
