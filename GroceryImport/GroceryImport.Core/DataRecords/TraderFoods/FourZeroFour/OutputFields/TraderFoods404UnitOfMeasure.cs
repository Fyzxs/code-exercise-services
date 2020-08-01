using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404UnitOfMeasure: UnitOfMeasure
    {
        private readonly ITraderFoods404InputRecord _inputRecord;

        public TraderFoods404UnitOfMeasure(ITraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        public override string AsSystemType() => _inputRecord.IsPerWeight() ? "Pound" : "Each";
    }
}