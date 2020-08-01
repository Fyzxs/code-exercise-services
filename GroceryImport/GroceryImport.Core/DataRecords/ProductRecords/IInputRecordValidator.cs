namespace GroceryImport.Core.DataRecords.ProductRecords
{
    public interface IInputRecordValidator
    {
        bool NotValidFormat(string record);
    }
}