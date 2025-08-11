// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.Abstractions.Models.Exceptions;
using Xeptions;

namespace ISL.Providers.Captcha.Abstractions.Tests.Unit.Models.Exceptions
{
    public class SomeCaptchaDependencyException : Xeption, ICaptchaProviderDependencyException
    {
        public SomeCaptchaDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
