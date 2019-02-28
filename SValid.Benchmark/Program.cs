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
            public SimpleClass ApplicativeStyle()
            {
                Result<Func<string, string, string, SimpleClass>, List<string>> Lift(Func<string, string, string, SimpleClass> f) =>
                    Result<Func<string, string, string, SimpleClass>, List<string>>.CreateOk(f);

                var firstPropValue = "someValue";
                var secondPropValue = "someOtherValue";
                var thirdPropValue = "yetAnotherValue";

                var liftedConstructor = Lift(SimpleClass.Create);
                var result = liftedConstructor
                    .Apply(
                        firstPropValue.NotEmpty()
                        .Merge(firstPropValue.MinLength(3))
                        .Merge(firstPropValue.MaxLength(100)))
                    .Apply(
                        secondPropValue.NotEmpty()
                        .Merge(secondPropValue.MinLength(3))
                        .Merge(secondPropValue.MaxLength(100)))
                    .Apply(
                        thirdPropValue.NotEmpty()
                        .Merge(thirdPropValue.MinLength(3))
                        .Merge(thirdPropValue.MaxLength(100)));

                if (result.IsOk()) return result.Ok;

                throw new InvalidOperationException();
            }

            [Benchmark]
            public SimpleClass HandmadeApplicativeStyle()
            {
                var firstPropValue = "someValue";
                var secondPropValue = "someOtherValue";
                var thirdPropValue = "yetAnotherValue";

                var validatedFirstProp =
                    firstPropValue.NotEmpty()
                        .Merge(firstPropValue.MinLength(3))
                        .Merge(firstPropValue.MaxLength(100));

                var validatedSecondProp =
                    secondPropValue.NotEmpty()
                        .Merge(secondPropValue.MinLength(3))
                        .Merge(secondPropValue.MaxLength(100));

                var validatedThirdProp =
                    thirdPropValue.NotEmpty()
                        .Merge(thirdPropValue.MinLength(3))
                        .Merge(thirdPropValue.MaxLength(100));

                if (validatedFirstProp.IsOk()
                    && validatedSecondProp.IsOk()
                    && validatedThirdProp.IsOk())
                    return new SimpleClass(validatedFirstProp.Ok, validatedSecondProp.Ok, validatedThirdProp.Ok);

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
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ValidationStylesTests>();
            Console.ReadKey();
        }
    }
}
