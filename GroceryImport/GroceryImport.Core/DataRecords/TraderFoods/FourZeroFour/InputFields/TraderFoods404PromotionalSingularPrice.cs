using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404PromotionalSingularPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 79;
        private const int EndIndexOnesBased = 86;

        public TraderFoods404PromotionalSingularPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
    internal sealed class TraderFoods404RegularSingularPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 70;
        private const int EndIndexOnesBased = 77;

        public TraderFoods404RegularSingularPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}