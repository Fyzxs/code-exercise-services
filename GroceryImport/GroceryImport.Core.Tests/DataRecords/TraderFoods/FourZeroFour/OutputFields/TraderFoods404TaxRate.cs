using GroceryImport.Core.Tests.DataRecords.ProductRecords;

namespace GroceryImport.Core.Tests.DataRecords.TraderFoods.FourZeroFour.OutputFields
{
    public sealed class TraderFoods404TaxRate : TaxRate
    {
        private const double Rate = 7.775 / 100d;
        public TraderFoods404TaxRate(bool isTaxable):base(isTaxable, Rate){}
    }
}