// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.Abstractions.Models.Exceptions;
using System.Collections;
using Xeptions;

namespace ISL.Providers.Captcha.Abstractions.Tests.Unit.Models.Exceptions
{
    public class SomeCaptchaValidationException : Xeption, ICaptchaProviderValidationException
    {
        public SomeCaptchaValidationException(string message, Xeption innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}
