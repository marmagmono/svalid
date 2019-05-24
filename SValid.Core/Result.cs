using System.Runtime.CompilerServices;

namespace SValid.Core
{
    public enum ResultTag { Ok, Error }

    public readonly struct Result<TOk>
    {
        public readonly ResultTag Outcome;

        public readonly TOk Ok;

        public readonly ErrorData Error;

        private Result(ResultTag outcome, in TOk ok, in ErrorData error)
        {
            Outcome = outcome;
            Ok = ok;
            Error = error;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk> CreateOk(in TOk ok) =>
            new Result<TOk>(ResultTag.Ok, ok, default);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk> CreateError(in ErrorData error) =>
            new Result<TOk>(ResultTag.Error, default, error);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TOk> operator&(
            in Result<TOk> res1,
            in Result<TOk> res2)
        {
            if (res1.IsOk() && res2.IsOk())
                return res1;
            else if (res1.IsOk() && res2.IsError())
                return res2;
            else if (res1.IsError() && res2.IsOk())
                return res1;
            else return CreateError(res1.Error.Merge(res2.Error));
        }
    }
}
