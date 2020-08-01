using GroceryImport.Core.Tests.DataRecords.FieldTypes;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404PromotionalForQuantity : NumberField
    {
        private const int StartIndexOnesBased = 115;
        private const int EndIndexOnesBased = 122;

        public TraderFoods404PromotionalForQuantity(Record record) : base(record, StartIndexOnesBased, EndIndexOnesBased)
        { }
    }
}