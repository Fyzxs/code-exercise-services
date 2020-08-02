using GroceryImport.Core.Exceptions;

namespace GroceryImport.Core.DataRecords.FieldTypes
{
    /// <summary>
    /// A Number Field from a record
    /// </summary>
    public class NumberField : Field<int>
    {
        public NumberField(IRecord record, int startIndexOnesBased, int inclusiveEndIndexOnesBased) : base(record, startIndexOnesBased, inclusiveEndIndexOnesBased) { }

        public override int AsSystemType()
        {
            string value = Value();
            if (!int.TryParse(value, out int result)) throw new InvalidNumberFieldException(this, value);
            return result;
        }
    }
}