// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Xeptions;

namespace ISL.Providers.Captcha.FakeCaptcha.Models.Foundations.Captcha.Exceptions
{
    public class CaptchaDependencyException : Xeption
    {
        public CaptchaDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
