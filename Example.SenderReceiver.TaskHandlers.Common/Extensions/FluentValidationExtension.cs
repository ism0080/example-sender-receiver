using FluentValidation;
using System;
using System.Collections.Generic;

namespace Example.SenderReceiver.TaskHandlers.Common.Extensions
{
    public static class FluentValidationExtension
    {
        public static void ValidateAndThrowPropertyBindingException<T>(this IValidator<T> validator, T settings)
        {
            var result = validator.Validate(settings);
            if (!result.IsValid)
            {
                var dict = new Dictionary<string, string>();
                foreach (var failure in result.Errors)
                    dict.Add(failure.PropertyName, failure.ErrorMessage);
                throw new Exception(dict.ToString());
            }
        }
    }
}
