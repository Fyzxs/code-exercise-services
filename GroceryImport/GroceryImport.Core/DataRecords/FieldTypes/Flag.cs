using GroceryImport.Core.Tests.Library;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    public abstract class Flag : ToSystem<bool>
    {
        private const string TrueValue = "Y";
        private readonly string _value;
        private readonly int _flagNumber;

        protected Flag(string value, int flagNumber)
        {
            _value = value;
            _flagNumber = flagNumber;
        }
        public override bool AsSystemType() => _value.Substring(_flagNumber - 1, 1) == TrueValue;
    }
}