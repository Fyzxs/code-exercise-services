namespace GroceryImport.Core.DataRecords.ProductRecords
{
    /// <summary>
    /// An object to be used to update the database.
    /// It's a class instead of an interface because the spec wanted an object.
    /// I'd probably suggest an update to an interface since I don't see any behavior that belongs here... Yet.
    /// </summary>
    public abstract class ProductRecord
    {
        public abstract string CompanyId();
        public abstract string StoreId();
        public abstract int ProductId();
        public abstract string ProductDescription();
        public abstract string ProductSize();
        public abstract decimal PromotionalCalculatorPrice();
        public abstract string PromotionalDisplayPrice();
        public abstract decimal RegularCalculatorPrice();
        public abstract string RegularDisplayPrice();
        public abstract double TaxRate();
        public abstract string UnitOfMeasure();
        public abstract bool IsPromotional();
        public abstract bool IsRegular();
    }
}