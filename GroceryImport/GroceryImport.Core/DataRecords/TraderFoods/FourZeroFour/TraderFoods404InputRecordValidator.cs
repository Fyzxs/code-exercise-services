using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public sealed class TraderFoods404InputRecordValidator : IInputRecordValidator
    {
        private const int SpecifiedRecordLength = 142;

        //TODO: Add more in depth error checking. To avoid ACTUALLY processing every field, spot checking the space between records would be a fast check with an increased accuracy over just length. Downside... giant list of indexes...
        public bool Invalid(string record) => record.Length != SpecifiedRecordLength;//Simplistic checking for correct length.
    }
}