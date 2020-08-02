using GroceryImport.Core.DataRecords.FieldTypes;

/*
 This file and the partial objects represents composite methods; or custom behavior that is not a 1:1 from the source record.
 */

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
        // Methods Sort by Scope then Alphabetically
        public bool HasPromotionalPricing() => HasPricing(PromotionalSingularPrice()) || HasPricing(PromotionalSplitPrice());

        public bool HasRegularPricing() => HasPricing(RegularSingularPrice()) || HasPricing(RegularSplitPrice());

        public Flag IsPerWeight() => Flags().PerWeight();

        public bool IsPromotionalSplitPrice() => HasPricing(PromotionalSplitPrice()) && HasQuantity(PromotionalForQuantity());

        public bool IsRegularSplitPrice() => HasPricing(RegularSplitPrice()) && HasQuantity(RegularForQuantity());

        public Flag IsTaxable() => Flags().Taxable();

        private bool HasPricing(decimal price) => 0m != price;
        private bool HasQuantity(int quantity) => 0 < quantity;
    }
}