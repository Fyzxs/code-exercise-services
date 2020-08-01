namespace GroceryImport.Core.DataRecords.ProductRecords
{
    public abstract class ProductRecord
    {
        public abstract string CompanyId();
        public abstract int ProductId();
        public abstract string ProductDescription();
        public abstract string ProductSize();
        public abstract decimal PromotionalCalculatorPrice();
        public abstract string PromotionalDisplayPrice();
        public abstract decimal RegularCalculatorPrice();
        public abstract string RegularDisplayPrice();
        public abstract string StoreId();
        public abstract double TaxRate();
        public abstract string UnitOfMeasure();
        public abstract bool IsPromotional();
        public abstract bool IsRegular();
    }
}