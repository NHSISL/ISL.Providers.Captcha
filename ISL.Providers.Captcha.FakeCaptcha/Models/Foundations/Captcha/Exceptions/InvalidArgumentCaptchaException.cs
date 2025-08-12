// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Xeptions;

namespace ISL.Providers.Captcha.FakeCaptcha.Models.Foundations.Captcha.Exceptions
{
    public class InvalidArgumentCaptchaException : Xeption
    {
        public InvalidArgumentCaptchaException(string message)
            : base(message)
        { }
    }
}
