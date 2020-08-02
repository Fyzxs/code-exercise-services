using GroceryImport.Core.Library;

namespace GroceryImport.Core.DataRecords.FieldTypes
{
    /// <summary>
    /// The idea is that general types of fields are being processed and they're structured at least somewhat similarly.
    /// With only one example, this may be completely wrong, but there's like to be commonality... So the code is going to act like there is.
    /// </summary>
    /// <typeparam name="T">The primitive type the data will map out to</typeparam>
    public abstract class Field<T> : ToSystem<T>
    {
        private readonly IRecord _record;
        private readonly int _startIndexOnesBased;
        private readonly int _inclusiveEndIndexOnesBased;

        protected Field(IRecord record, int startIndexOnesBased, int inclusiveEndIndexOnesBased)
        {
            _record = record;
            _startIndexOnesBased = startIndexOnesBased;
            _inclusiveEndIndexOnesBased = inclusiveEndIndexOnesBased;
        }

        protected string Value() => _record.FieldStringValue(_startIndexOnesBased, _inclusiveEndIndexOnesBased);
    }
}