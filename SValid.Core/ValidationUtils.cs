using System;
using System.Collections.Generic;

namespace SValid.Core
{
    public static class ValidationUtils
    {
        public static Result<TResult> CreateValidated<TArg1, TResult>(
            Func<TArg1, TResult> constructor,
            in Result<TArg1> arg1)
        {
            if (arg1.IsOk())
            {
                return Result<TResult>.CreateOk(constructor(arg1.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(arg1.Error);
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TResult>(
            Func<TArg1, TArg2, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2)
        {
            if (arg1.IsOk() && arg2.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TResult>(
            Func<TArg1, TArg2, TArg3, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4,
            string arg5ModelName, in Result<TArg5> arg5)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk() && arg5.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok, arg5.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                    new KeyValuePair<string, ErrorData>(arg5ModelName, arg5.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4,
            string arg5ModelName, in Result<TArg5> arg5,
            string arg6ModelName, in Result<TArg6> arg6)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk() && arg5.IsOk() && arg6.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok, arg5.Ok, arg6.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                    new KeyValuePair<string, ErrorData>(arg5ModelName, arg5.Error),
                    new KeyValuePair<string, ErrorData>(arg6ModelName, arg6.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4,
            string arg5ModelName, in Result<TArg5> arg5,
            string arg6ModelName, in Result<TArg6> arg6,
            string arg7ModelName, in Result<TArg7> arg7)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk() && arg5.IsOk() && arg6.IsOk() && arg7.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok, arg5.Ok, arg6.Ok, arg7.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                    new KeyValuePair<string, ErrorData>(arg5ModelName, arg5.Error),
                    new KeyValuePair<string, ErrorData>(arg6ModelName, arg6.Error),
                    new KeyValuePair<string, ErrorData>(arg7ModelName, arg7.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4,
            string arg5ModelName, in Result<TArg5> arg5,
            string arg6ModelName, in Result<TArg6> arg6,
            string arg7ModelName, in Result<TArg7> arg7,
            string arg8ModelName, in Result<TArg8> arg8)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk() && arg5.IsOk() && arg6.IsOk() && arg7.IsOk() && arg8.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok, arg5.Ok, arg6.Ok, arg7.Ok, arg8.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                    new KeyValuePair<string, ErrorData>(arg5ModelName, arg5.Error),
                    new KeyValuePair<string, ErrorData>(arg6ModelName, arg6.Error),
                    new KeyValuePair<string, ErrorData>(arg7ModelName, arg7.Error),
                    new KeyValuePair<string, ErrorData>(arg8ModelName, arg8.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4,
            string arg5ModelName, in Result<TArg5> arg5,
            string arg6ModelName, in Result<TArg6> arg6,
            string arg7ModelName, in Result<TArg7> arg7,
            string arg8ModelName, in Result<TArg8> arg8,
            string arg9ModelName, in Result<TArg9> arg9)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk() && arg5.IsOk() && arg6.IsOk() && arg7.IsOk() && arg8.IsOk() && arg9.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok, arg5.Ok, arg6.Ok, arg7.Ok, arg8.Ok, arg9.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                    new KeyValuePair<string, ErrorData>(arg5ModelName, arg5.Error),
                    new KeyValuePair<string, ErrorData>(arg6ModelName, arg6.Error),
                    new KeyValuePair<string, ErrorData>(arg7ModelName, arg7.Error),
                    new KeyValuePair<string, ErrorData>(arg8ModelName, arg8.Error),
                    new KeyValuePair<string, ErrorData>(arg9ModelName, arg9.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4,
            string arg5ModelName, in Result<TArg5> arg5,
            string arg6ModelName, in Result<TArg6> arg6,
            string arg7ModelName, in Result<TArg7> arg7,
            string arg8ModelName, in Result<TArg8> arg8,
            string arg9ModelName, in Result<TArg9> arg9,
            string arg10ModelName, in Result<TArg10> arg10)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk() && arg5.IsOk() && arg6.IsOk() && arg7.IsOk() && arg8.IsOk() && arg9.IsOk() && arg10.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok, arg5.Ok, arg6.Ok, arg7.Ok, arg8.Ok, arg9.Ok, arg10.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                    new KeyValuePair<string, ErrorData>(arg5ModelName, arg5.Error),
                    new KeyValuePair<string, ErrorData>(arg6ModelName, arg6.Error),
                    new KeyValuePair<string, ErrorData>(arg7ModelName, arg7.Error),
                    new KeyValuePair<string, ErrorData>(arg8ModelName, arg8.Error),
                    new KeyValuePair<string, ErrorData>(arg9ModelName, arg9.Error),
                    new KeyValuePair<string, ErrorData>(arg10ModelName, arg10.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4,
            string arg5ModelName, in Result<TArg5> arg5,
            string arg6ModelName, in Result<TArg6> arg6,
            string arg7ModelName, in Result<TArg7> arg7,
            string arg8ModelName, in Result<TArg8> arg8,
            string arg9ModelName, in Result<TArg9> arg9,
            string arg10ModelName, in Result<TArg10> arg10,
            string arg11ModelName, in Result<TArg11> arg11)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk() && arg5.IsOk() && arg6.IsOk() && arg7.IsOk() && arg8.IsOk() && arg9.IsOk() && arg10.IsOk() && arg11.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok, arg5.Ok, arg6.Ok, arg7.Ok, arg8.Ok, arg9.Ok, arg10.Ok, arg11.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                    new KeyValuePair<string, ErrorData>(arg5ModelName, arg5.Error),
                    new KeyValuePair<string, ErrorData>(arg6ModelName, arg6.Error),
                    new KeyValuePair<string, ErrorData>(arg7ModelName, arg7.Error),
                    new KeyValuePair<string, ErrorData>(arg8ModelName, arg8.Error),
                    new KeyValuePair<string, ErrorData>(arg9ModelName, arg9.Error),
                    new KeyValuePair<string, ErrorData>(arg10ModelName, arg10.Error),
                    new KeyValuePair<string, ErrorData>(arg11ModelName, arg11.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4,
            string arg5ModelName, in Result<TArg5> arg5,
            string arg6ModelName, in Result<TArg6> arg6,
            string arg7ModelName, in Result<TArg7> arg7,
            string arg8ModelName, in Result<TArg8> arg8,
            string arg9ModelName, in Result<TArg9> arg9,
            string arg10ModelName, in Result<TArg10> arg10,
            string arg11ModelName, in Result<TArg11> arg11,
            string arg12ModelName, in Result<TArg12> arg12)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk() && arg5.IsOk() && arg6.IsOk() && arg7.IsOk() && arg8.IsOk() && arg9.IsOk() && arg10.IsOk() && arg11.IsOk() && arg12.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok, arg5.Ok, arg6.Ok, arg7.Ok, arg8.Ok, arg9.Ok, arg10.Ok, arg11.Ok, arg12.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                    new KeyValuePair<string, ErrorData>(arg5ModelName, arg5.Error),
                    new KeyValuePair<string, ErrorData>(arg6ModelName, arg6.Error),
                    new KeyValuePair<string, ErrorData>(arg7ModelName, arg7.Error),
                    new KeyValuePair<string, ErrorData>(arg8ModelName, arg8.Error),
                    new KeyValuePair<string, ErrorData>(arg9ModelName, arg9.Error),
                    new KeyValuePair<string, ErrorData>(arg10ModelName, arg10.Error),
                    new KeyValuePair<string, ErrorData>(arg11ModelName, arg11.Error),
                    new KeyValuePair<string, ErrorData>(arg12ModelName, arg12.Error),
                        }));
            }
        }

        public static Result<TResult> CreateValidated<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult>(
            Func<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TResult> create,
            string arg1ModelName, in Result<TArg1> arg1,
            string arg2ModelName, in Result<TArg2> arg2,
            string arg3ModelName, in Result<TArg3> arg3,
            string arg4ModelName, in Result<TArg4> arg4,
            string arg5ModelName, in Result<TArg5> arg5,
            string arg6ModelName, in Result<TArg6> arg6,
            string arg7ModelName, in Result<TArg7> arg7,
            string arg8ModelName, in Result<TArg8> arg8,
            string arg9ModelName, in Result<TArg9> arg9,
            string arg10ModelName, in Result<TArg10> arg10,
            string arg11ModelName, in Result<TArg11> arg11,
            string arg12ModelName, in Result<TArg12> arg12,
            string arg13ModelName, in Result<TArg13> arg13)
        {
            if (arg1.IsOk() && arg2.IsOk() && arg3.IsOk() && arg4.IsOk() && arg5.IsOk() && arg6.IsOk() && arg7.IsOk() && arg8.IsOk() && arg9.IsOk() && arg10.IsOk() && arg11.IsOk() && arg12.IsOk() && arg13.IsOk())
            {
                return Result<TResult>.CreateOk(create(arg1.Ok, arg2.Ok, arg3.Ok, arg4.Ok, arg5.Ok, arg6.Ok, arg7.Ok, arg8.Ok, arg9.Ok, arg10.Ok, arg11.Ok, arg12.Ok, arg13.Ok));
            }
            else
            {
                return Result<TResult>.CreateError(
                    ErrorData.ModelError(
                        new KeyValuePair<string, ErrorData>[] {
                    new KeyValuePair<string, ErrorData>(arg1ModelName, arg1.Error),
                    new KeyValuePair<string, ErrorData>(arg2ModelName, arg2.Error),
                    new KeyValuePair<string, ErrorData>(arg3ModelName, arg3.Error),
                    new KeyValuePair<string, ErrorData>(arg4ModelName, arg4.Error),
                    new KeyValuePair<string, ErrorData>(arg5ModelName, arg5.Error),
                    new KeyValuePair<string, ErrorData>(arg6ModelName, arg6.Error),
                    new KeyValuePair<string, ErrorData>(arg7ModelName, arg7.Error),
                    new KeyValuePair<string, ErrorData>(arg8ModelName, arg8.Error),
                    new KeyValuePair<string, ErrorData>(arg9ModelName, arg9.Error),
                    new KeyValuePair<string, ErrorData>(arg10ModelName, arg10.Error),
                    new KeyValuePair<string, ErrorData>(arg11ModelName, arg11.Error),
                    new KeyValuePair<string, ErrorData>(arg12ModelName, arg12.Error),
                    new KeyValuePair<string, ErrorData>(arg13ModelName, arg13.Error),
                        }));
            }
        }

    }
}
