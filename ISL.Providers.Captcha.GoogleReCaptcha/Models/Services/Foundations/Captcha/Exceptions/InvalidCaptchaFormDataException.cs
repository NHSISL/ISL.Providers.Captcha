// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Xeptions;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha.Exceptions
{
    public class InvalidCaptchaFormDataException : Xeption
    {
        public InvalidCaptchaFormDataException(string message)
            : base(message)
        { }
    }
}
