using System;

namespace GroceryImport.Core.Tests.Library.Maths
{
    public interface IRounding
    {
        decimal RoundForCalculator(decimal value);
    }

    public sealed class InexactRounding : IRounding
    {
        /*
            .NET Math.Round doesn't have an exact match for Half Round Down (https://en.wikipedia.org/wiki/Rounding#Round_half_down)
            This should be updated with a more exact library, or implemented here (don't do that).

            We can see from the following tests/examples where each of the available .NET MidpointRounding  options fail
            A) 23.49 => 23
            B) 23.5 => 23
            C) 23.51 => 24
            D) -23.49 => -23
            E) -23.5 => -24
            F) -23.51 => -24

            MidpointRounding.ToPositiveInfinity
                Fails on A, B, F, and E

            MidpointRounding.ToNegativeInfinity
                Fails on C, D, and E
               
            MidpointRounding.ToZero
                Fails on C, E, and F

            MidpointRounding.AwayFromZero
                Fails on B

            MidpointRounding.ToEven
                Fails on B

                This needs an extra set of test with the ones place as an even number.
                    A') 24.49 => 24
                    B') 24.5 => 24
                    C') 24.51 => 25
                    D') -24.49 => -24
                    E') -24.5 => -25
                    F') -24.51 => -25
                Fails on E'

            While it's not perfect, to get things going, "AwayFromZero" is used as the least failing of all the options.
        */
        public decimal RoundForCalculator(decimal value) => Math.Round(value, 4, MidpointRounding.AwayFromZero);
    }
}