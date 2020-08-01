namespace GroceryImport.Core.DataRecords.FieldTypes
{
    public abstract class StringField : Field<string>
    {
        protected StringField(IRecord record, int startIndexOnesBased, int endIndexOnesBased) : base(record, startIndexOnesBased, endIndexOnesBased) { }

        public override string AsSystemType() => Value().Trim();
    }
}