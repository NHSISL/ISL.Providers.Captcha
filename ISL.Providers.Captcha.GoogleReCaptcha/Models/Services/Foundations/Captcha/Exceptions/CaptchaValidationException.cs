// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Xeptions;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha.Exceptions
{
    public class CaptchaValidationException : Xeption
    {
        public CaptchaValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
