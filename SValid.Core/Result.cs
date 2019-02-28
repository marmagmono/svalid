using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SValid.Core
{
    public enum ResultTag { Ok, Error }

    public readonly struct Result<TOk, TError>
    {
        public readonly ResultTag Outcome;

        public readonly TOk Ok;

        public readonly TError Error;

        private Result(ResultTag outcome, in TOk ok, in TError error)
        {
            Outcome = outcome;
            Ok = ok;
            Error = error;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk, TError> CreateOk(in TOk ok) =>
            new Result<TOk, TError>(ResultTag.Ok, ok, default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk, TError> CreateError(in TError error) =>
            new Result<TOk, TError>(ResultTag.Error, default, error);

        public static implicit operator Result<TOk, List<TError>>(in Result<TOk, TError> res) =>
            res.IsOk() ?
                Result<TOk, List<TError>>.CreateOk(res.Ok)
                : Result<TOk, List<TError>>.CreateError(new List<TError>() { res.Error });

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk, List<TError>> operator&(
            in Result<TOk, TError> res1,
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
        public static Result<TOk, List<TError>> operator&(
            in Result<TOk, List<TError>> res1,
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
