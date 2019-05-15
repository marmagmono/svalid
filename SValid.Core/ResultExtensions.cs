using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SValid.Core
{
    public delegate Result<TOk2, TError> BindFDelegate<TOk1, TOk2, TError>(TOk1 ok);

    public static class ResultExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOk<TOk, TError>(
            in this Result<TOk, TError> input) => input.Outcome == ResultTag.Ok;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsError<TOk, TError>(
            in this Result<TOk, TError> input) => input.Outcome == ResultTag.Error;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk2, TError> Bind<TOk1, TOk2, TError>(
            in this Result<TOk1, TError> input,
            BindFDelegate<TOk1, TOk2, TError> del)
        {
            if (input.Outcome == ResultTag.Error)
                return Result<TOk2, TError>.CreateError(input.Error);

            return del(input.Ok);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk, List<TError>> Merge<TOk, TError>(
            in this Result<TOk, TError> res1,
            in Result<TOk, TError> res2) => res1 & res2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk, List<TError>> Merge<TOk, TError>(
            in this Result<TOk, List<TError>> res1,
            in Result<TOk, TError> res2) => res1 & res2;
    }
}
