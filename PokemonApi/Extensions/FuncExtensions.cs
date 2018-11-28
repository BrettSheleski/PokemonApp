using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApi.Extensions
{
    public static class FuncExtensions
    {
        public static Func<T, bool> And<T>(this Func<T, bool> thisFunc, Func<T, bool> other)
        {
            return x => thisFunc(x) && other(x);
        }
    }
}
