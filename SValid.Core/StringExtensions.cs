using System;

namespace SValid.Core
{
    public static class StringExtensions
    {
        public static ErrorData ToError(this string s) => new SingleError(s);
    }
}
