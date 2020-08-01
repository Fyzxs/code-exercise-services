namespace GroceryImport.Core.Tests.Fakes
{
    public sealed class FakeChainInformation : IChainInformation
    {
        private readonly string _companyId;

        public FakeChainInformation(string companyId) => _companyId = companyId;

        public string CompanyId() => _companyId;
    }
}