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
    }
}
