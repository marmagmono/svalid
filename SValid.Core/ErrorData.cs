using System.Collections.Generic;

namespace SValid.Core
{
    public abstract class ErrorData
    {
        public static SimpleData SimpleData(string errorCode) => new SimpleData(errorCode);
        public static ComplexData ComplexData(IReadOnlyList<KeyValuePair<string, ErrorData>> propertyErrors) => new ComplexData(propertyErrors);
    }

    public sealed class SimpleData : ErrorData
    {
        public string ErrorCode { get; }

        public SimpleData(string errorCode)
        {
            ErrorCode = errorCode;
        }
    }

    public sealed class ComplexData : ErrorData
    {
        public IReadOnlyList<KeyValuePair<string, ErrorData>> PropertyErrors { get; }

        public ComplexData(IReadOnlyList<KeyValuePair<string, ErrorData>> propertyErrors)
        {
            PropertyErrors = propertyErrors;
        }
    }
}
