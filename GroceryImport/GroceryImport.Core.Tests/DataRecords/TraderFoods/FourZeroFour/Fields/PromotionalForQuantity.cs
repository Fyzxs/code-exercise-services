using GroceryImport.Core.Tests.DataRecords.BaseTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.Fields
{
    internal sealed class PromotionalForQuantity : NumberField
    {
        private const int StartIndexOnesBased = 115;
        private const int EndIndexOnesBased = 122;

        public PromotionalForQuantity(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}