using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public sealed class TraderFoods404InputRecordValidator : IInputRecordValidator
    {
        private const int SpecifiedRecordLength = 142;

        public bool NotValidFormat(string record) => record.Length != SpecifiedRecordLength;//Simplistic checking for correct length.
    }
}