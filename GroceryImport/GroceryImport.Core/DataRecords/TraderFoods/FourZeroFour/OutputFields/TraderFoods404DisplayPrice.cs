using GroceryImport.Core.DataRecords.FieldTypes;
using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    internal sealed class TraderFoods404SplitDisplayPrice : DisplayPrice
    {
        private readonly CurrencyField _splitPrice;
        private readonly NumberField _forQuantity;

        public TraderFoods404SplitDisplayPrice(CurrencyField splitPrice, NumberField forQuantity)
        {
            _splitPrice = splitPrice;
            _forQuantity = forQuantity;
        }

        public override string AsSystemType() => $"{_forQuantity.AsSystemType()} for {_splitPrice.AsCurrencyString()}";
    }
}