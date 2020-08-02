namespace GroceryImport.Core.DataRecords.FieldTypes
{
    public interface IRecord
    {
        /// <summary>
        /// Retrieves the Field as a string. The field is determined by the <see cref="startIndexOnesBased"/> and <see cref="inclusiveEndIndexOnesBased"/>
        /// </summary>
        /// <param name="startIndexOnesBased">The "ones based" starting index.</param>
        /// <param name="inclusiveEndIndexOnesBased">The inclusive "ones based" ending index.</param>
        /// <returns>The string value </returns>
        string FieldStringValue(int startIndexOnesBased, int inclusiveEndIndexOnesBased);
    }

    /// <summary>
    /// A Currency Field from a record
    /// </summary>
    public sealed class Record : IRecord
    {
        private readonly string _record;

        public Record(string record) => _record = record;

        public string FieldStringValue(int startIndexOnesBased, int inclusiveEndIndexOnesBased) => _record.Substring(StartIndex(startIndexOnesBased), EndIndex(startIndexOnesBased, inclusiveEndIndexOnesBased));

        private static int EndIndex(int startIndexOnesBased, int inclusiveEndIndexOnesBased) => inclusiveEndIndexOnesBased - StartIndex(startIndexOnesBased);

        private static int StartIndex(int startIndexOnesBased) => startIndexOnesBased - 1;
    }
}