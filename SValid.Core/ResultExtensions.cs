using System.Collections.Generic;
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
            in Result<TOk, TError> res2)
        {
            if (res1.IsOk() && res2.IsOk())
                return Result<TOk, List<TError>>.CreateOk(res1.Ok);
            else if (res1.IsOk() && res2.IsError())
                return Result<TOk, List<TError>>.CreateError(new List<TError>() { res2.Error });
            else if (res1.IsError() && res2.IsOk())
                return Result<TOk, List<TError>>.CreateError(new List<TError>() { res1.Error });
            else return Result<TOk, List<TError>>.CreateError(new List<TError>() { res1.Error, res2.Error });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk, List<TError>> Merge<TOk, TError>(
            in this Result<TOk, List<TError>> res1,
            in Result<TOk, TError> res2)
        {
            if (res1.IsOk() && res2.IsOk())
                return res1;
            else if (res1.IsOk() && res2.IsError())
                return Result<TOk, List<TError>>.CreateError(new List<TError>() { res2.Error });
            else if (res1.IsError() && res2.IsOk())
                return Result<TOk, List<TError>>.CreateError(new List<TError>(res1.Error));
            else return Result<TOk, List<TError>>.CreateError(new List<TError>(res1.Error) { res2.Error });
        }
    }
}
