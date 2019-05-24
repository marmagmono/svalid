using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using SValid.Core;
using SValid.Core.StringValidation;
using System;
using System.Collections.Generic;

namespace SValid.Benchmark
{
    public class Program
    {
        public class SimpleClass
        {
            public string FirstProperty { get; }
            public string SecondProperty { get; }
            public string ThirdProperty { get; }

            public SimpleClass(string firstProperty, string secondProperty, string thirdProperty)
            {
                FirstProperty = firstProperty;
                SecondProperty = secondProperty;
                ThirdProperty = thirdProperty;
            }

            public static SimpleClass Create(string firstProperty, string secondProperty, string thirdProperty) =>
                new SimpleClass(firstProperty, secondProperty, thirdProperty);
        }

        public class ValidationStylesTests
        {
            [Benchmark]
            public SimpleClass HandmadeApplicativeStyle()
            {
                var firstPropValue = "someValue";
                var secondPropValue = "someOtherValue";
                var thirdPropValue = "yetAnotherValue";

                var validatedFirstProp =
                    firstPropValue.NotEmpty()
                    & firstPropValue.MinLength(3)
                    & firstPropValue.MaxLength(100);

                var validatedSecondProp =
                    secondPropValue.NotEmpty()
                    & secondPropValue.MinLength(3)
                    & secondPropValue.MaxLength(100);

                var validatedThirdProp =
                    thirdPropValue.NotEmpty()
                    & thirdPropValue.MinLength(3)
                    & thirdPropValue.MaxLength(100);

                if (validatedFirstProp.IsOk()
                    && validatedSecondProp.IsOk()
                    && validatedThirdProp.IsOk())
                    return new SimpleClass(validatedFirstProp.Ok, validatedSecondProp.Ok, validatedThirdProp.Ok);

                throw new InvalidOperationException();
            }

            [Benchmark]
            public SimpleClass HandmadeApplicativeStyleVariation()
            {
                var firstPropValue = "someValue";
                var secondPropValue = "someOtherValue";
                var thirdPropValue = "yetAnotherValue";

                var validatedFirstProp =
                    firstPropValue.NotEmpty()
                    & firstPropValue.MinLength(3)
                    & firstPropValue.MaxLength(100);

                var validatedSecondProp =
                    secondPropValue.NotEmpty()
                    & secondPropValue.MinLength(3)
                    & secondPropValue.MaxLength(100);

                var validatedThirdProp =
                    thirdPropValue.NotEmpty()
                    & thirdPropValue.MinLength(3)
                    & thirdPropValue.MaxLength(100);

                if (validatedFirstProp.IsOk()
                    && validatedSecondProp.IsOk()
                    && validatedThirdProp.IsOk())
                    return new SimpleClass(validatedFirstProp.Ok, validatedSecondProp.Ok, validatedThirdProp.Ok);

                throw new InvalidOperationException();
            }

            private delegate T CreateFunc<T, TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3);

            [Benchmark]
            public SimpleClass HandmadeApplicativeStyleVariationWithFunction()
            {
                var firstPropValue = "someValue";
                var secondPropValue = "someOtherValue";
                var thirdPropValue = "yetAnotherValue";

                var validatedFirstProp =
                    firstPropValue.NotEmpty()
                    & firstPropValue.MinLength(3)
                    & firstPropValue.MaxLength(100);

                var validatedSecondProp =
                    secondPropValue.NotEmpty()
                    & secondPropValue.MinLength(3)
                    & secondPropValue.MaxLength(100);

                var validatedThirdProp =
                    thirdPropValue.NotEmpty()
                    & thirdPropValue.MinLength(3)
                    & thirdPropValue.MaxLength(100);

                return ValidationUtils.CreateValidated(
                    (a1, a2, a3) => new SimpleClass(a1, a2, a3),
                    nameof(validatedFirstProp), validatedFirstProp,
                    nameof(validatedSecondProp), validatedSecondProp,
                    nameof(validatedThirdProp), validatedThirdProp).Ok;
            }

            [Benchmark]
            public SimpleClass OutChaining()
            {
                var firstPropValue = "someValue";
                var secondPropValue = "someOtherValue";
                var thirdPropValue = "yetAnotherValue";

                bool isFirstOk = NotEmpty(firstPropValue, out var notEmptyRes1)
                    && MinLength(firstPropValue, 3, out var minLength1)
                    && MaxLength(firstPropValue, 100, out var maxLength1);

                bool isSecondOk =
                    NotEmpty(secondPropValue, out var notEmptyRes2)
                    && MinLength(secondPropValue, 3, out var minLength2)
                    && MaxLength(secondPropValue, 100, out var maxLength2);

                bool isThirdOk =
                    NotEmpty(thirdPropValue, out var notEmptyRes3)
                    && MinLength(thirdPropValue, 3, out var minLength3)
                    && MaxLength(thirdPropValue, 100, out var maxLength3);

                if (isFirstOk
                    && isSecondOk
                    && isThirdOk)
                    return new SimpleClass(notEmptyRes1.Result, notEmptyRes2.Result, notEmptyRes3.Result);

                throw new InvalidOperationException();
            }

            private delegate bool TestFunction(string s, out FResult result);

            private static bool Applicative(string s, TestFunction f1, TestFunction f2, TestFunction f3, out FResult result)
            {
                bool firstResult = f1(s, out var f1Res);
                bool secondResult = f2(s, out var f2Res);
                bool thirdResult = f3(s, out var f3Res);

                bool success = firstResult && secondResult && thirdResult;
                if (success)
                {
                    result = new FResult(s, null);
                }
                else
                {
                    result = new FResult(null, "fsfdsfs");
                }

                return success;
            }

            private static bool MinLength3(string s, out FResult result) => MinLength(s, 3, out result);
            private static bool MaxLength100(string s, out FResult result) => MaxLength(s, 100, out result);

            [Benchmark]
            public SimpleClass OutChainingFunction()
            {
                var firstPropValue = "someValue";
                var secondPropValue = "someOtherValue";
                var thirdPropValue = "yetAnotherValue";

                bool isFirstOk = Applicative(firstPropValue, NotEmpty, MinLength3, MaxLength100, out var notEmptyRes1);
                bool isSecondOk = Applicative(secondPropValue, NotEmpty, MinLength3, MaxLength100, out var notEmptyRes2);
                bool isThirdOk = Applicative(thirdPropValue, NotEmpty, MinLength3, MaxLength100, out var notEmptyRes3);

                if (isFirstOk
                    && isSecondOk
                    && isThirdOk)
                    return new SimpleClass(notEmptyRes1.Result, notEmptyRes2.Result, notEmptyRes3.Result);

                throw new InvalidOperationException();
            }

            [Benchmark]
            public SimpleClass BoringClassic()
            {

                var firstPropValue = "someValue";
                var secondPropValue = "someOtherValue";
                var thirdPropValue = "yetAnotherValue";

                bool isFirstOk =
                    !string.IsNullOrEmpty(firstPropValue)
                    && firstPropValue.Length >= 3
                    && firstPropValue.Length <= 100;

                bool isSecondOk =
                    !string.IsNullOrEmpty(secondPropValue)
                    && secondPropValue.Length >= 3
                    && secondPropValue.Length <= 100;

                bool isThirdOk =
                    !string.IsNullOrEmpty(thirdPropValue)
                    && thirdPropValue.Length >= 3
                    && thirdPropValue.Length <= 100;

                if (isFirstOk
                    && isSecondOk
                    && isThirdOk)
                    return new SimpleClass(firstPropValue, secondPropValue, thirdPropValue);

                throw new InvalidOperationException();
            }

            private static bool NotEmpty(string s, out FResult result)
            {
                if (string.IsNullOrEmpty(s))
                {
                    result = new FResult(null, "fs33333");
                    return false;
                }
                else
                {
                    result = new FResult(s, null);
                    return true;
                }
            }

            private static bool MaxLength(string s, int length, out FResult result)
            {
                if (s.Length > length)
                {
                    result = new FResult(null, "fdsfds");
                    return false;
                }
                else
                {
                    result = new FResult(s, null);
                    return true;
                }
            }

            private static bool MinLength(string s, int length, out FResult result)
            {
                if (s.Length < length)
                {
                    result = new FResult(null, "fdsfds");
                    return false;
                }
                else
                {
                    result = new FResult(s, null);
                    return true;
                }
            }

            private readonly struct FResult
            {
                public readonly string Result;
                public readonly string ErrorCode;

                public FResult(string result, string errorCode)
                {
                    Result = result;
                    ErrorCode = errorCode;
                }
            }
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ValidationStylesTests>();
            Console.ReadKey();
        }
    }
}
