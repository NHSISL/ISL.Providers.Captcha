// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections;
using Xeptions;

namespace ISL.Providers.Captcha.Abstractions.Models.Exceptions
{
    public class CaptchaProviderValidationException : Xeption
    {
        public CaptchaProviderValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }

        public CaptchaProviderValidationException(string message, Xeption innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}
