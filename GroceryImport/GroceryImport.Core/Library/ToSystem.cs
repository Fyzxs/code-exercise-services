using System.Diagnostics;

namespace GroceryImport.Core.Library
{
    /// <summary>
    /// This class allows implicit conversion to system/primitive types and is intended to simplify our No Primitives stance when at the interface to another system.
    /// This should be used with a Marker Class (see https://en.wikipedia.org/wiki/Marker_interface_pattern except a class not interface).
    /// 
    /// Primary reasons for this class are:
    /// * Enables a strict approach to "No Primitives". No Primitives is a massive reduction in the complexity of code.
    /// * Enables a strict approach to abstracting 3rd party code. Our code can be ignorant of external types except where absolutely needed.
    /// * Allows the edges of our system to do ignorant conversion to the externally required types.
    /// * Types become owners of their conversions by implementation of the abstract <see cref="AsSystemType"/>. Conversion is a behavior, it belongs in the class.
    /// </summary>
    /// <typeparam name="TSystemType">The 3rd party type to convert to. Most often a Primitive type to feed into another system.</typeparam>
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