namespace GroceryImport.Core.Tests.DataRecords.FieldTypes
{
    public sealed class Record
    {
        private readonly string _record;

        public Record(string record) => _record = record;

        public string FieldStringValue(int startIndexOnesBased, int endIndexOnesBased) => _record.Substring(StartIndex(startIndexOnesBased), EndIndex(startIndexOnesBased, endIndexOnesBased));

        private static int EndIndex(int startIndexOnesBased, int endIndexOnesBased) => endIndexOnesBased - StartIndex(startIndexOnesBased);

        private static int StartIndex(int startIndexOnesBased) => startIndexOnesBased - 1;
    }
}