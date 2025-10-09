// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections;
using ISL.Providers.Captcha.Abstractions.Models.Exceptions;
using Xeptions;

namespace ISL.Providers.Captcha.Abstractions.Tests.Unit.Models.Exceptions
{
    public class SomeCaptchaServiceException : Xeption, ICaptchaProviderServiceException
    {
        public SomeCaptchaServiceException(string message, Xeption innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}
