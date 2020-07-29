using System;

namespace GroceryImport.Core.Tests.Exceptions
{
    public sealed class InvalidNumberFieldException : Exception
    {
        public InvalidNumberFieldException(object obj, string value) : base($"Invalid Number Field [value={value}] found in [type={obj.GetType().FullName}]") { }
    }
}