using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public partial interface ITraderFoods404InputRecord
    {
        bool HasPromotionalPricing();
        bool HasRegularPricing();
        Flag IsPerWeight();
        bool IsPromotionalSplitPrice();
        bool IsRegularSplitPrice();
        Flag IsTaxable();
    }

    public sealed partial class TraderFoods404InputRecord
    {
        // Methods Sorted Alphabetically
        public bool HasPromotionalPricing() => 0m != PromotionalSingularPrice() || 0m != PromotionalSplitPrice();

        public bool HasRegularPricing() => 0m != RegularSingularPrice() || 0m != RegularSplitPrice();

        public Flag IsPerWeight() => Flags().PerWeight();

        public bool IsPromotionalSplitPrice() => HasPromotionalPricing() && 0 < PromotionalForQuantity();
        
        public bool IsRegularSplitPrice() => HasRegularPricing() && 0 < RegularForQuantity();

        public Flag IsTaxable() => Flags().Taxable();
    }
}