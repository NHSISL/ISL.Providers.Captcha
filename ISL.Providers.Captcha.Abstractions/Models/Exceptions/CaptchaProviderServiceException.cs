// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections;
using Xeptions;

namespace ISL.Providers.Captcha.Abstractions.Models.Exceptions
{
    public class CaptchaProviderServiceException : Xeption
    {
        public CaptchaProviderServiceException(string message, Xeption innerException)
            : base(message, innerException)
        { }

        public CaptchaProviderServiceException(string message, Xeption innerException, IDictionary data)
            : base(message, innerException, data)
        { }
    }
}
