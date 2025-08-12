// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Xeptions;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha
{
    public class CaptchaDependencyException : Xeption
    {
        public CaptchaDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
