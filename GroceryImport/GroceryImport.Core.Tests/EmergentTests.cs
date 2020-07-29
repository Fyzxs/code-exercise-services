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
        public void ProductRecord_ShouldReturnProductId_FromProductSample4()
        {
            //Arrange
            ProductRecordCompanyStore productRecord = new ProductRecordCompanyStore("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            string actual = productRecord.Get("ProductId");

            //Assert
            actual.Should().Be("14963801");
        }
        [TestMethod, TestCategory("unit")]
        public void ProductRecord_ShouldBeANumber()
        {
            //Arrange
            ProductRecordCompanyStore productRecord = new ProductRecordCompanyStore("14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            //Act
            string actual = productRecord.Get("ProductId");

            //Assert
            actual.Should().Be("14963801");
        }
    }

    public sealed partial class ProductRecordCompanyStore : ProductRecord
    {
        private readonly string _record;

        private static readonly RecordFieldCollection Collection = new RecordFieldCollection
        {
            new ProductId()
        };

        public ProductRecordCompanyStore(string record) => _record = record;

        public bool AllFieldsValid()
        {
            foreach (IField field in Collection)
            {
                try
                {
                    field.Value(_record);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        private string Value(string key) => Collection[key].Value(_record);
        public override string ProductId => KeyValue("ProductId");
        public override Money PromotionalSplitPrice => KeyValue("ProductId").AsCurrency();
    }

    public abstract class ProductRecord
    {
        public abstract string ProductId {get;}
        public abstract Money PromotionalSplitPrice { get; }
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
        public string Value(string record) => record.Substring(0, 8-0);

        public string FieldKey() => "ProductId";
    }

    public sealed class PromotionalSplitPrice : IField
    {
        public string Value(string record) => record.Substring(78, 86-78);

        public string FieldKey() => "PromotionalSplitPrice";
    }

    public interface IField
    {
        public string Value(string record);
        string FieldKey();
    }

}
