namespace GroceryImport.Core.DataRecords.FieldTypes
{
    public abstract class FlagsField : Field<string>
    {
        protected FlagsField(IRecord record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override string AsSystemType() => Value();
    }
}