using System;
using System.Collections.Generic;

namespace SValid.Core
{
    public static class ErrorDataExtensions
    {
        public static ErrorData Merge(this ErrorData e1, in ErrorData e2)
        {
            switch (e1)
            {
                case SingleError se1:
                    switch (e2)
                    {
                        case SingleError se2:
                            return new MultipleErrors(BuildErrorList(se1, se2));
                        case MultipleErrors me2:
                            return new MultipleErrors(BuildErrorList(se1, me2.Errors));
                        case ModelError me2:
                            return new MultipleErrors(BuildErrorList(e1, me2));
                        default:
                            throw new ArgumentOutOfRangeException(nameof(e2));
                    }

                case MultipleErrors me1:
                    switch (e2)
                    {
                        case SingleError se2:
                            return new MultipleErrors(BuildErrorList(me1.Errors, se2));
                        case MultipleErrors me2:
                            return new MultipleErrors(BuildErrorList(me1.Errors, me2.Errors));
                        case ModelError me2:
                            return new MultipleErrors(BuildErrorList(me1.Errors, me2));
                        default:
                            throw new ArgumentOutOfRangeException(nameof(e2));
                    }

                case ModelError me1:
                    switch (e2)
                    {
                        case SingleError se2:
                            return new MultipleErrors(BuildErrorList(me1, se2));
                        case MultipleErrors me2:
                            return new MultipleErrors(BuildErrorList(me1, me2.Errors));
                        case ModelError me2:
                            return new MultipleErrors(BuildErrorList(me1, me2)); // Or try merge model error lists ?
                        default:
                            throw new ArgumentOutOfRangeException(nameof(e2));
                    }

                default: throw new ArgumentOutOfRangeException(nameof(e1));
            }
        }

        private static List<ErrorData> BuildErrorList(ErrorData singleError, ErrorData singleError2) =>
            new List<ErrorData>() { singleError, singleError2 };

        private static List<ErrorData> BuildErrorList(ErrorData singleError, List<ErrorData> multipleErrors)
        {
            var l = new List<ErrorData>();
            l.Add(singleError);
            l.AddRange(multipleErrors);
            return l;
        }

        private static List<ErrorData> BuildErrorList(List<ErrorData> multipleErrors1, List<ErrorData> multipleErrors2)
        {
            var l = new List<ErrorData>();
            l.AddRange(multipleErrors1);
            l.AddRange(multipleErrors2);
            return l;
        }

        private static List<ErrorData> BuildErrorList(List<ErrorData> multipleErrors, ErrorData singleError)
        {
            var l = new List<ErrorData>();
            l.AddRange(multipleErrors);
            l.Add(singleError);
            return l;
        }
    }
}
