using System.Diagnostics;

namespace GroceryImport.Core.Library
{
    /// <summary>
    /// This class allows automatic conversion to system/primitive types at the edge of our system.
    /// This should be used with a Marker Class (see https://en.wikipedia.org/wiki/Marker_interface_pattern except a class not interface).
    /// 
    /// The reasons for this class are:
    /// * Enables a strict approach approach to "No Primitives".
    /// * Allows the edges of the system ignorant conversion to the externally required types. Types become owners of their conversions by
    /// implementation of the abstract <see cref="AsSystemType"/>.
    /// </summary>
    /// <typeparam name="TSystemType"></typeparam>
    [DebuggerDisplay("{AsSystemType()}")]
    public abstract class ToSystem<TSystemType>
    {
        /// <summary>
        /// The implicit operator to the generic type allows automatic conversion to system/primitive types at the edge of our system.
        /// </summary>
        /// <param name="origin">The object to get the <typeparamref name="TSystemType"/> value from.</param>
        public static implicit operator TSystemType(ToSystem<TSystemType> origin) => origin.AsSystemType();

        /// <summary>
        /// Retrieves the value of the type from the concrete class explicitly.
        /// </summary>
        /// <returns>The converted value of the implementing type.</returns>
        public abstract TSystemType AsSystemType();
    }
}