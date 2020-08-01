using System.IO;
using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public sealed class TraderFoods404OutputRecordCollection : ProductRecordCollection
    {
        public TraderFoods404OutputRecordCollection(string fileLocation) :this(new StreamReader(fileLocation)){}
        public TraderFoods404OutputRecordCollection(StreamReader streamReader) : base((StreamReader) streamReader, (IProductRecordFactory) new TraderFoods404ProductRecordFactory(), (IInputRecordValidator) new TraderFoods404InputRecordValidator()){}
    }
}