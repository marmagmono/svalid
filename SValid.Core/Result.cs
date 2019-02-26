using System.Runtime.CompilerServices;

namespace SValid.Core
{
    public enum ResultTag { Ok, Error }

    public readonly struct Result<TOk, TError>
    {
        public ResultTag Outcome { get; }

        public TOk Ok { get; }

        public TError Error { get; }

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
    }
}
