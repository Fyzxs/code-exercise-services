namespace GroceryImport.Core.DataRecords.FieldTypes
{
    public interface IRecord
    {
        string FieldStringValue(int startIndexOnesBased, int endIndexOnesBased);
    }

    public sealed class Record : IRecord
    {
        private readonly string _record;

        public Record(string record) => _record = record;

        public string FieldStringValue(int startIndexOnesBased, int endIndexOnesBased) => _record.Substring(StartIndex(startIndexOnesBased), EndIndex(startIndexOnesBased, endIndexOnesBased));

        private static int EndIndex(int startIndexOnesBased, int endIndexOnesBased) => endIndexOnesBased - StartIndex(startIndexOnesBased);

        private static int StartIndex(int startIndexOnesBased) => startIndexOnesBased - 1;
    }
}