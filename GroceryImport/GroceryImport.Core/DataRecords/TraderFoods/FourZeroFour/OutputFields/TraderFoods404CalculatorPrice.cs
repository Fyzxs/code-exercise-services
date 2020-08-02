using GroceryImport.Core.DataRecords.FieldTypes;
using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    internal sealed class TraderFoods404CalculatorSingularPrice : CalculatorPrice
    {
        private readonly CurrencyField _price;
        
        public TraderFoods404CalculatorSingularPrice(CurrencyField price) => _price = price;

        public override decimal AsSystemType() => _price;
    }
}