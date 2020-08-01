using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404PromotionalSplitPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 97;
        private const int EndIndexOnesBased = 104;

        public TraderFoods404PromotionalSplitPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}