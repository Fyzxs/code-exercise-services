using GroceryImport.Core.Tests.DataRecords.ProductRecords;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404UnitOfMeasure: UnitOfMeasure
    {
        private readonly TraderFoods404InputRecord _inputRecord;

        public TraderFoods404UnitOfMeasure(TraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override string AsSystemType() => _inputRecord.IsPerWeight() ? "Pound" : "Each";
    }
}