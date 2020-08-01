using GroceryImport.Core.Exceptions;

namespace GroceryImport.Core.DataRecords.FieldTypes
{
    public abstract class CurrencyField : Field<decimal>
    {
        //TODO: Currency requires a money object - I'm being a bit forgiving in this exercise

        protected CurrencyField(IRecord record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public string AsCurrencyString() => AsSystemType().ToString("C");

        public override decimal AsSystemType()
        {
            string value = Value();
            if (!int.TryParse(value, out int result)) throw new InvalidCurrencyFieldException(this, value);

            return result / 100m;
        }
    }
}