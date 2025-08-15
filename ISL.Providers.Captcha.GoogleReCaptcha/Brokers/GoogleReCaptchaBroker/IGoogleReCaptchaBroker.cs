// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker
{
    internal interface IGoogleReCaptchaBroker
    {
        ValueTask<HttpResponseMessage> ValidateCaptchaAsync(Dictionary<string, string> formData);
    }
}