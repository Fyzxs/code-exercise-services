namespace GroceryImport.Core.DataRecords.FieldTypes
{
    /// <summary>
    /// A String Field from a record
    /// </summary>
    public abstract class StringField : Field<string>
    {
        protected StringField(IRecord record, int startIndexOnesBased, int inclusiveEndIndexOnesBased) : base(record, startIndexOnesBased, inclusiveEndIndexOnesBased) { }

        public override string AsSystemType() => Value().Trim();
    }
}