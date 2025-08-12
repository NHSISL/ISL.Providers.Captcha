// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections;
using Xeptions;

namespace ISL.Providers.Captcha.FakeCaptcha.Models.Foundations.Captcha.Exceptions
{
    public class FailedServiceCaptchaException : Xeption
    {
        public FailedServiceCaptchaException(string message, Exception innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}
