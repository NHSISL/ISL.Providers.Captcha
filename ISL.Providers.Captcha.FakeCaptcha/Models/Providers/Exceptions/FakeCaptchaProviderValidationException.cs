// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.Abstractions.Models.Exceptions;
using System.Collections;
using Xeptions;

namespace ISL.Providers.Captcha.FakeCaptcha.Models.Providers.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the provider.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class FakeCaptchaProviderValidationException : Xeption, ICaptchaProviderValidationException
    {
        public FakeCaptchaProviderValidationException(string message, Xeption innerException, IDictionary data)
            : base(message: message, innerException, data)
        { }
    }
}
