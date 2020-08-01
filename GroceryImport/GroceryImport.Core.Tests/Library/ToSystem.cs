using System.Diagnostics;

namespace GroceryImport.Core.Tests.Library
{
    [DebuggerDisplay("{AsSystemType()}")]
    public abstract class ToSystem<TSystemType>
    {
        public static implicit operator TSystemType(ToSystem<TSystemType> origin) => origin.AsSystemType();

        public abstract TSystemType AsSystemType();
    }
}