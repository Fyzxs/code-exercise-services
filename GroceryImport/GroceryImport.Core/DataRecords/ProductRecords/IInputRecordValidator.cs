namespace GroceryImport.Core.DataRecords.ProductRecords
{
    /// <summary>
    /// Supports validation of record 
    /// </summary>
    public interface IInputRecordValidator
    {
        /// <summary>
        /// Used to see if the provided string value is not a valid record
        /// </summary>
        /// <param name="record">the string representation of the record to be validated</param>
        /// <returns>True if the record is invalid. False if the record is not Invalid</returns>
        bool Invalid(string record);
    }
}