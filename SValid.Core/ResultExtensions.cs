using System.Runtime.CompilerServices;

namespace SValid.Core
{
    public static class ResultExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOk<TOk>(
            in this Result<TOk> input) => input.Outcome == ResultTag.Ok;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsError<TOk>(
            in this Result<TOk> input) => input.Outcome == ResultTag.Error;
    }
}
