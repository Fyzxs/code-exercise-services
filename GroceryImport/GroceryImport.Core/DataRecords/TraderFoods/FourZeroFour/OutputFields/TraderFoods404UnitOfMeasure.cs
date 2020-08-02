using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    internal sealed class TraderFoods404UnitOfMeasure: UnitOfMeasure
    {
        private readonly ITraderFoods404InputRecord _inputRecord;

        public TraderFoods404UnitOfMeasure(ITraderFoods404InputRecord inputRecord) => _inputRecord = inputRecord;

        //TODO: "Pound" should be loaded from somewhere else to accomodate future metric systems and localization
        //TODO: "Each" should probably also be loaded from somewhere... especially for localization
        public override string AsSystemType() => _inputRecord.IsPerWeight() ? "Pound" : "Each";
    }
}