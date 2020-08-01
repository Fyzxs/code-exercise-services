using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using GroceryImport.Core.DataRecords.ProductRecords;
using GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable TestFileNameWarning

namespace GroceryImport.Core.Tests
{
    [TestClass]
    public class EmergentTests
    {
        /*
ID       DESCRIPTION                                                 RegSing$ PrmSng$  RegSpt$  PrmSpt$  RegForX  PrmForX  FLAGS       ProductSize
80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz
14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz
40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb
         */
        [TestMethod, TestCategory("unit")]
        public void MostlyTestingMultipleEnumerations()
        {
            //Arrange
            string inMemoryFile = @"80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz
14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz
40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb";
            StreamReader streamReader = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(inMemoryFile)));
            TraderFoods404OutputRecordCollection subject = new TraderFoods404OutputRecordCollection(streamReader);

            //Act
            int ctr = subject.Count();
            int ctr2 = subject.Count();
            int ctr3 = 0;

            foreach (ProductRecord productRecord in subject)
            {
                ctr3++;
            }

            int ctr4 = 0;
            using (IEnumerator<ProductRecord> enumerator = subject.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ctr4++;
                }
            }

            //Assert
            ctr.Should().Be(4);
            ctr2.Should().Be(4);
            ctr3.Should().Be(4);
            ctr4.Should().Be(4);
        }

        [TestMethod, TestCategory("unit")]
        public void FileReader_ShouldSkipIncorrectLengthFields()
        {
            //Arrange
            string inMemoryFile = @"80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz
14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz
40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN          12x12oz
50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN";
            StreamReader streamReader = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(inMemoryFile)));
            TraderFoods404OutputRecordCollection subject = new TraderFoods404OutputRecordCollection(streamReader);

            //Act
            int ctr = subject.Count();

            //Assert
            ctr.Should().Be(4);
        }
    }

    public sealed class TraderFoods404OutputRecordCollection : ProductRecordCollection
    {
        public TraderFoods404OutputRecordCollection(string fileLocation) :this(new StreamReader(fileLocation)){}
        public TraderFoods404OutputRecordCollection(StreamReader streamReader) : base(streamReader, new TraderFoods404ProductRecordFactory(), new TraderFoods404InputRecordValidator()){}
    }

    public sealed class TraderFoods404InputRecordValidator : IInputRecordValidator
    {
        private const int SpecifiedRecordLength = 142;

        public bool NotValidFormat(string record) => record.Length != SpecifiedRecordLength;//Simplistic checking for correct length.
    }
    public sealed class TraderFoods404ProductRecordFactory : IProductRecordFactory
    {
        public ProductRecord Create(string record) => new TraderFoods404OutputRecord(record);
    }

    public interface IProductRecordFactory
    {
        ProductRecord Create(string record);
    }

    public interface IInputRecordValidator
    {
        bool NotValidFormat(string record);
    }


    public abstract class ProductRecordCollection : IEnumerable<ProductRecord>
    {
        private readonly StreamReader _streamReader;
        private readonly IProductRecordFactory _factory;
        private readonly IInputRecordValidator _validator;

        protected ProductRecordCollection(StreamReader streamReader, IProductRecordFactory factory, IInputRecordValidator validator)
        {
            _streamReader = streamReader;
            _factory = factory;
            _validator = validator;
        }
        
        public IEnumerator<ProductRecord> GetEnumerator()
        {
            string record;
            while (null != (record = _streamReader.ReadLine()))
            {
                if (_validator.NotValidFormat(record)) continue;

                yield return _factory.Create(record);
            }

            _streamReader.BaseStream.Position = 0;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
