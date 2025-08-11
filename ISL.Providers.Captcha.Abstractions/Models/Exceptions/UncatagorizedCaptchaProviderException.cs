// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections;
using Xeptions;

namespace ISL.Providers.Captcha.Abstractions.Models.Exceptions
{
    public class UncatagorizedCaptchaProviderException : Xeption
    {
        public UncatagorizedCaptchaProviderException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public UncatagorizedCaptchaProviderException(string message, Exception innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}
