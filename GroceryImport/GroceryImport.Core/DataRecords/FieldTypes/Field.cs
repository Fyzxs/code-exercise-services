using GroceryImport.Core.Tests.Library;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    public abstract class Field<T> : ToSystem<T>
    {
        private readonly Record _record;
        private readonly int _startIndexOnesBased;
        private readonly int _endIndexOnesBased;

        protected Field(Record record, int startIndexOnesBased, int endIndexOnesBased)
        {
            _record = record;
            _startIndexOnesBased = startIndexOnesBased;
            _endIndexOnesBased = endIndexOnesBased;
        }

        protected string Value() => _record.FieldStringValue(_startIndexOnesBased, _endIndexOnesBased);
    }
}