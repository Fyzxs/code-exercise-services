namespace GroceryImport.Core.DataRecords.ProductRecords
{
    /// <summary>
    /// Supports creating a <see cref="ProductRecord"/> derived type dynamically
    /// </summary>
    public interface IProductRecordFactory
    {
        /// <summary>
        /// Creates an instance of class derived from <see cref="ProductRecord"/>
        /// </summary>
        /// <param name="record">The string representation of the record to be processed into a ProductRecord</param>
        /// <returns>An instance of a <see cref="ProductRecord"/> derived type</returns>
        ProductRecord Create(string record);
    }
}