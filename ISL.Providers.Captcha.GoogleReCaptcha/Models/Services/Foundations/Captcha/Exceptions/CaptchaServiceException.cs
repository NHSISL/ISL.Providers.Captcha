// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Xeptions;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha.Exceptions
{
    public class CaptchaServiceException : Xeption
    {
        public CaptchaServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
