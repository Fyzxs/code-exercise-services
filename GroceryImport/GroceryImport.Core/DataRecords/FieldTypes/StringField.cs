namespace GroceryImport.Core.DataRecords.FieldTypes
{
    public abstract class StringField : Field<string>
    {
        protected StringField(IRecord record, int startIndexOnesBased, int inclusiveEndIndexOnesBased) : base(record, startIndexOnesBased, inclusiveEndIndexOnesBased) { }

        public override string AsSystemType() => Value().Trim();
    }
}