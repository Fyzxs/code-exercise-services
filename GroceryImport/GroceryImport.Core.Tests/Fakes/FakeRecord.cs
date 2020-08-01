using GroceryImport.Core.DataRecords.FieldTypes;

namespace GroceryImport.Core.Tests.Fakes
{
    public sealed class FakeRecord : IRecord
    {
        private readonly string _returnValue;

        public FakeRecord(string returnValue) => _returnValue = returnValue;

        public string FieldStringValue(int startIndexOnesBased, int endIndexOnesBased) => _returnValue;
    }
}