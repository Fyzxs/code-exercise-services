using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.InputFields
{
    internal sealed class TraderFoods404ProductSize:StringField
    {
        public TraderFoods404ProductSize(IRecord record) : base(record, 134, 142)
        {}
    }
}