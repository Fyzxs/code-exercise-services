using GroceryImport.Core.DataRecords.FieldTypes;
using GroceryImport.Core.DataRecords.ProductRecords;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    internal sealed class TraderFoods404SingularDisplayPrice : DisplayPrice
    {
        private readonly CurrencyField _price;

        public TraderFoods404SingularDisplayPrice(CurrencyField price) => _price = price;

        public override string AsSystemType() => _price.AsCurrencyString();
    }
}