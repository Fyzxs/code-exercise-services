namespace GroceryImport.Core.Tests.BaseTypes
{
    public abstract class FlagsField : Field<string>
    {
        protected FlagsField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override string AsSystemType() => Value();
    }
}