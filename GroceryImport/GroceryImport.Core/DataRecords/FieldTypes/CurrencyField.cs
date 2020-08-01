using GroceryImport.Core.Tests.Exceptions;

namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    public abstract class CurrencyField : Field<decimal>
    {
        //TODO: Currency requires a money object - I'm being a bit forgiving here. We'll see how long I stay that way.

        protected CurrencyField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public string AsCurrencyString() => AsSystemType().ToString("C");

        public override decimal AsSystemType()
        {
            string value = Value();
            if (!int.TryParse(value, out int result)) throw new InvalidCurrencyFieldException(this, value);

            return result / 100m;
        }
    }
}