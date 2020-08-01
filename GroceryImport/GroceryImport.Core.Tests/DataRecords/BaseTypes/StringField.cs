namespace GroceryImport.Core.Tests.DataRecords.BaseTypes
{
    public abstract class StringField : Field<string>
    {
        protected StringField(Record record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override string AsSystemType() => Value().Trim();
    }
}