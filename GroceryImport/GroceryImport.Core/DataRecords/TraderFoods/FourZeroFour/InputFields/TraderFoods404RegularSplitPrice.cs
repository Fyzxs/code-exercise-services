using GroceryImport.Core.Tests.DataRecords.FieldTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404RegularSplitPrice : CurrencyField
    {
        private const int StartIndexOnesBased = 88;
        private const int EndIndexOnesBased = 95;

        public TraderFoods404RegularSplitPrice(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}