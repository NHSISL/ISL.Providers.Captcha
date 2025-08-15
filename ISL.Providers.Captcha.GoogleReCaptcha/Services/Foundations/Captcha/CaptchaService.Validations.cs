// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha.Exceptions;
using System;
using System.Collections.Generic;
using Xeptions;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha
{
    internal partial class CaptchaService
    {
        virtual internal void ValidateCaptchaValidationArguments(string captchaToken)
        {
            Validate<InvalidCaptchaArgumentException>(
                message: "Invalid Captcha argument. Please correct the errors and try again.",
                (Rule: IsInvalid(captchaToken), Parameter: nameof(captchaToken)));
        }

        virtual internal void ValidateFormData(Dictionary<string, string> formData)
        {
            Validate<InvalidCaptchaFormDataException>(
                message: "Invalid Captcha form data. Please correct the errors and try again.",
                (Rule: IsInvalid(formData["secret"]), Parameter: "secret"),
                (Rule: IsInvalid(formData["response"]), Parameter: "response"));
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is invalid."
        };

        private static void Validate<T>(string message, params (dynamic Rule, string Parameter)[] validations)
            where T : Xeption
        {
            var invalidDataException = (T?)Activator.CreateInstance(typeof(T), message);

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidDataException?.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidDataException?.ThrowIfContainsErrors();
        }
    }
}
