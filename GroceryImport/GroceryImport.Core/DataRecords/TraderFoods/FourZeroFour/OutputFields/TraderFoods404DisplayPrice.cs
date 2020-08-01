using GroceryImport.Core.DataRecords.FieldTypes;
using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404DisplayPrice : DisplayPrice
    {
        private readonly bool _isSplitPrice;
        private readonly CurrencyField _splitPrice;
        private readonly NumberField _forQuantity;

        public TraderFoods404DisplayPrice(in bool isSplitPrice, CurrencyField splitPrice, NumberField forQuantity)
        {
            _isSplitPrice = isSplitPrice;
            _splitPrice = splitPrice;
            _forQuantity = forQuantity;
        }
        public override string AsSystemType()
        {
            if (_isSplitPrice) return $"{_forQuantity.AsSystemType()} for {_splitPrice.AsCurrencyString()}";

            return _splitPrice.AsCurrencyString();
        }
    }
}