// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha.Exceptions;
using System;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha
{
    internal partial class CaptchaService
    {
        virtual internal void ValidateCaptchaValidationArguments(string captchaToken)
        {
            Validate((Rule: IsInvalid(captchaToken), Parameter: nameof(captchaToken)));
        }

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is invalid."
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidArgumentCaptchaException =
                new InvalidCaptchaArgumentException(
                    message: "Invalid Captcha argument. Please correct the errors and try again.");

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidArgumentCaptchaException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidArgumentCaptchaException.ThrowIfContainsErrors();
        }
    }
}
