using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public sealed class TraderFoods404ProductRecordFactory : IProductRecordFactory
    {
        public ProductRecord Create(string record) => new TraderFoods404OutputRecord(record);
    }
}