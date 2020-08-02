namespace GroceryImport.Core.DataRecords.FieldTypes
{
    /// <summary>
    /// A Flags Field from a record
    /// </summary>
    public abstract class FlagsField : Field<string>
    {
        protected FlagsField(IRecord record, int startIndexOnesBased, int inclusiveEndIndexOnesBased) : base(record, startIndexOnesBased, inclusiveEndIndexOnesBased) { }

        public override string AsSystemType() => Value();
    }
}