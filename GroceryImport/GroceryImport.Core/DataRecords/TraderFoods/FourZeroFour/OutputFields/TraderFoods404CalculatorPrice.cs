using GroceryImport.Core.Tests.DataRecords.FieldTypes;
using GroceryImport.Core.Tests.DataRecords.ProductRecords;
using GroceryImport.Core.Tests.Library.Maths;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404CalculatorPrice : CalculatorPrice
    {
        private readonly bool _isSplitPrice;
        private readonly CurrencyField _splitPrice;
        private readonly NumberField _forQuantity;
        private readonly IRounding _rounding;

        public TraderFoods404CalculatorPrice(bool isSplitPrice, CurrencyField splitPrice, NumberField forQuantity) : this(isSplitPrice, splitPrice, forQuantity, new InexactRounding()){}
        
        private TraderFoods404CalculatorPrice(in bool isSplitPrice, CurrencyField splitPrice, NumberField forQuantity, IRounding rounding)
        {
            _isSplitPrice = isSplitPrice;
            _splitPrice = splitPrice;
            _forQuantity = forQuantity;
            _rounding = rounding;
        }
        public override decimal AsSystemType()
        {
            if (_isSplitPrice) return _rounding.RoundForCalculator(_splitPrice / _forQuantity);

            return _splitPrice;
        }
    }
}