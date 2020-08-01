using GroceryImport.Core.Tests.DataRecords.FieldTypes;
using GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.InputFields;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour
{
    public sealed partial class TraderFoods404InputRecord
    {
        private readonly Record _record;

        public TraderFoods404InputRecord(string record) : this(new Record(record))
        { }

        private TraderFoods404InputRecord(Record record) => _record = record;

        // Input Fields should be in the order they appear in the record.
        public NumberField ProductId() => new TraderFoods404ProductId(_record);
        public StringField ProductDescription() => new TraderFoods404ProductDescription(_record);
        public CurrencyField RegularSingularPrice() => new TraderFoods404RegularSingularPrice(_record);
        public CurrencyField PromotionalSingularPrice() => new TraderFoods404PromotionalSingularPrice(_record);
        public CurrencyField RegularSplitPrice() => new TraderFoods404RegularSplitPrice(_record);
        public CurrencyField PromotionalSplitPrice() => new TraderFoods404PromotionalSplitPrice(_record);
        public NumberField RegularForQuantity() => new TraderFoods404RegularForQuantity(_record);
        public NumberField PromotionalForQuantity() => new TraderFoods404PromotionalForQuantity(_record);
        private TraderFoods404Flags Flags() => new TraderFoods404Flags(_record);
        public StringField ProductSize() => new TraderFoods404ProductSize(_record);
    }
}