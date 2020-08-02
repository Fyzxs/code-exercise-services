using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404PromotionalSplitPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 97;
        private const int InclusiveEndIndexOnesBased = 104;

        public TraderFoods404PromotionalSplitPrice(IRecord record) : base(record, StartIndexOnesBased, InclusiveEndIndexOnesBased)
        { }
    }
}