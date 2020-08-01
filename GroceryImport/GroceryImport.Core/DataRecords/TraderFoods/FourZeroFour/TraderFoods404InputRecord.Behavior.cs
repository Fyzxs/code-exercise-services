using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public partial interface ITraderFoods404InputRecord
    {
        Flag IsPerWeight();
        bool IsPromotionalSplitPrice();
        bool IsRegularSplitPrice();
        Flag IsTaxable();
    }

    public sealed partial class TraderFoods404InputRecord
    {
        // Methods Sorted Alphabetically
        public Flag IsPerWeight() => Flags().PerWeight();
        
        public bool IsPromotionalSplitPrice() => PromotionalForQuantity() > 0;
        
        public bool IsRegularSplitPrice() => RegularForQuantity() > 0;

        public Flag IsTaxable() => Flags().Taxable();
    }
}