using GroceryImport.Core.Tests.Exceptions;

namespace GroceryImport.Core.Tests.DataRecords.BaseTypes
{
    public class NumberField : Field<int>
    {
        public NumberField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override int AsSystemType()
        {
            string value = Value();
            if (!int.TryParse(value, out int result)) throw new InvalidNumberFieldException(this, value);
            return result;
        }
    }
}