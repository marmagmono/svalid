using System.Runtime.CompilerServices;

namespace SValid.Core.StringValidation
{
    using StringValidationResult = Result<string, string>;

    public static class StringValidationExtensions
    {
        public const string EmptyErrorCode = "E1000:Empty";
        public const string TooShortErrorCode = "E1001:TooShort";
        public const string TooLongErrorCode = "E1002:TooLong";
        public const string InvalidLengthErrorCode = "E1003:InvalidLength";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringValidationResult NotEmpty(
            this string s,
            string errorCode = EmptyErrorCode)
        {
            return string.IsNullOrEmpty(s) ?
                StringValidationResult.CreateError(errorCode)
                : StringValidationResult.CreateOk(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringValidationResult MinLength(
            this string s,
            uint minLength,
            string errorCode = TooShortErrorCode)
        {
            return s?.Length < minLength ?
                StringValidationResult.CreateError(errorCode)
                : StringValidationResult.CreateOk(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringValidationResult MaxLength(
            this string s,
            uint maxLength,
            string errorCode = TooLongErrorCode)
                {
            return s?.Length > maxLength ?
                StringValidationResult.CreateError(errorCode)
                : StringValidationResult.CreateOk(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StringValidationResult SpecifiedLength(
            this string s,
            uint minLength,
            uint maxLength,
            string errorCode = InvalidLengthErrorCode)
        {
            return s?.Length > maxLength || s?.Length < minLength ?
                StringValidationResult.CreateError(errorCode)
                : StringValidationResult.CreateOk(s);
        }
    }
}
