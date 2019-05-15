using SValid.Core;
using SValid.Core.StringValidation;
using System;
using System.Collections.Generic;

namespace SValid.Console
{
    class Program
    {
        private class SimpleClass : Exception
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
            var firstPropValue = "someValue";
            var secondPropValue = "someOtherValue";
            var thirdPropValue = "yetAnotherValue";

            var validatedFirstProp =
                firstPropValue.NotEmpty()
                & firstPropValue.MinLength(3)
                & firstPropValue.MaxLength(100)
                & firstPropValue.MaxLength(300)
                & firstPropValue.MaxLength(400)
                & firstPropValue.MaxLength(500);

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
                throw new SimpleClass(validatedFirstProp.Ok, validatedSecondProp.Ok, validatedThirdProp.Ok);

            System.Console.ReadKey();
        }
    }
}
