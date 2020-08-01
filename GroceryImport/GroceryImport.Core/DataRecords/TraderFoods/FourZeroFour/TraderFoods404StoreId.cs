using GroceryImport.Core.Library;

namespace GroceryImport.Core.DataRecords.TraderFoods.FourZeroFour
{
    public sealed class TraderFoods404StoreId : ToSystem<string>
    {
        private const string StoreIdValue = "404";

        private readonly IChainInformation _chainInformation;
        public TraderFoods404StoreId(IChainInformation chainInformation) => _chainInformation = chainInformation;

        public override string AsSystemType() => $"{_chainInformation.CompanyId()}:{StoreIdValue}";
    }
}