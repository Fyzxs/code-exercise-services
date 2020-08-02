using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404PromotionalForQuantity : NumberField
    {
        private const int StartIndexOnesBased = 115;
        private const int InclusiveEndIndexOnesBased = 122;

        public TraderFoods404PromotionalForQuantity(IRecord record) : base(record, StartIndexOnesBased, InclusiveEndIndexOnesBased)
        { }
    }
}