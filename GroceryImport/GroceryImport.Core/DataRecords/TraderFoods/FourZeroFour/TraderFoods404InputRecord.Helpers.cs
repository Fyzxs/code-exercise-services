using GroceryImport.Core.Tests.DataRecords.FieldTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour
{
    public sealed partial class TraderFoods404InputRecord
    {
        // Helper Methods Sorted Alphabetically
        public Flag IsPerWeight() => Flags().PerWeight();
        
        public bool IsPromotionalSplitPrice() => PromotionalForQuantity() > 0;
        
        public bool IsRegularSplitPrice() => RegularForQuantity() > 0;

        public Flag IsTaxable() => Flags().Taxable();
    }
}