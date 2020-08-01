namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    public abstract class FlagsField : Field<string>
    {
        protected FlagsField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override string AsSystemType() => Value();
    }
}