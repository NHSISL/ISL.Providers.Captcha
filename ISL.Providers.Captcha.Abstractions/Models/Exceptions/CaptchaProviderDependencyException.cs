// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections;
using Xeptions;

namespace ISL.Providers.Captcha.Abstractions.Models.Exceptions
{
    public class CaptchaProviderDependencyException : Xeption
    {
        public CaptchaProviderDependencyException(string message, Xeption innerException)
            : base(message, innerException)
        { }

        public CaptchaProviderDependencyException(string message, Xeption innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}
