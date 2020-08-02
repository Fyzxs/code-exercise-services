using System.IO;
using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public sealed class TraderFoods404ProductRecordCollection : ProductRecordCollection
    {
        public TraderFoods404ProductRecordCollection(string fileLocation) :this(new StreamReader(fileLocation)){}
        public TraderFoods404ProductRecordCollection(StreamReader streamReader) : base(streamReader, new TraderFoods404ProductRecordFactory(), new TraderFoods404InputRecordValidator()){}
    }
}