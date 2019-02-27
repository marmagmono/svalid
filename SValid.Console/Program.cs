using SValid.Core;
using SValid.Core.StringValidation;
using System;
using System.Collections.Generic;

namespace SValid.Console
{
    class Program
    {
        private class SimpleClass
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

        static void Main(string[] args)
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

            System.Console.ReadKey();
        }
    }
}
