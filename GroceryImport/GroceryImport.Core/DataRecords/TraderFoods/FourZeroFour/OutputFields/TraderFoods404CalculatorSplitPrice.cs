using GroceryImport.Core.DataRecords.FieldTypes;
using GroceryImport.Core.DataRecords.ProductRecords;
using GroceryImport.Core.Library.Maths;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    internal sealed class TraderFoods404CalculatorSplitPrice : CalculatorPrice
    {
        private readonly CurrencyField _splitPrice;
        private readonly NumberField _forQuantity;
        private readonly IRounding _rounding;

        public TraderFoods404CalculatorSplitPrice(CurrencyField splitPrice, NumberField forQuantity) : this(splitPrice, forQuantity, new InexactRounding()) { }

        private TraderFoods404CalculatorSplitPrice(CurrencyField splitPrice, NumberField forQuantity, IRounding rounding)
        {
            _splitPrice = splitPrice;
            _forQuantity = forQuantity;
            _rounding = rounding;
        }

        public override decimal AsSystemType() => _rounding.RoundForCalculator(_splitPrice / _forQuantity);
    }
}