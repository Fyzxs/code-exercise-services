using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404PromotionalSingularPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 79;
        private const int InclusiveEndIndexOnesBased = 86;

        public TraderFoods404PromotionalSingularPrice(IRecord record) : base(record, StartIndexOnesBased, InclusiveEndIndexOnesBased)
        { }
    }
}