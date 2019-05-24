using System.Collections.Generic;

namespace SValid.Core
{
    public abstract class ErrorData
    {
        public static SingleError SingleError(string errorCode) => new SingleError(errorCode);

        public static MultipleErrors MultipleErrors(List<ErrorData> errors) => new MultipleErrors(errors);

        public static ModelError ModelError(IReadOnlyList<KeyValuePair<string, ErrorData>> propertyErrors) => new ModelError(propertyErrors);
    }

    public sealed class SingleError : ErrorData
    {
        public string ErrorCode { get; }

        public SingleError(string errorCode)
        {
            ErrorCode = errorCode;
        }
    }

    public sealed class MultipleErrors : ErrorData
    {
        public List<ErrorData> Errors { get; }

        public MultipleErrors(List<ErrorData> errors)
        {
            Errors = errors;
        }
    }

    public sealed class ModelError : ErrorData
    {
        public IReadOnlyList<KeyValuePair<string, ErrorData>> PropertyErrors { get; }

        public ModelError(IReadOnlyList<KeyValuePair<string, ErrorData>> propertyErrors)
        {
            PropertyErrors = propertyErrors;
        }
    }
}
