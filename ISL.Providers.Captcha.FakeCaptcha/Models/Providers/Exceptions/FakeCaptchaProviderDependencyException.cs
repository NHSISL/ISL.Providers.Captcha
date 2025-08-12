// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.Abstractions.Models.Exceptions;
using Xeptions;

namespace ISL.Providers.Captcha.FakeCaptcha.Models.Providers.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the provider.
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class FakeCaptchaProviderDependencyException : Xeption, ICaptchaProviderDependencyException
    {
        public FakeCaptchaProviderDependencyException(string message, Xeption innerException)
            : base(message: message, innerException)
        { }
    }
}
