namespace GroceryImport.Core.DataRecords.ProductRecords
{
    public interface IProductRecordFactory
    {
        ProductRecord Create(string record);
    }
}