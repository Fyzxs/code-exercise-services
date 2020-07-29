using System;

namespace GroceryImport.Core.Tests.Exceptions
{
    public sealed class InvalidCurrencyFieldException : Exception
    {
        public InvalidCurrencyFieldException(object obj, string value) : base($"Invalid Currency Field [value={value}] found in [type={obj.GetType().FullName}]") { }
    }
}