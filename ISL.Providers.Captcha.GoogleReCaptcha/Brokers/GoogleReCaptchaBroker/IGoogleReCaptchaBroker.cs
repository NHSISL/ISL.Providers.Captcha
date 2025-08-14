// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using System.Threading.Tasks;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker
{
    internal interface IGoogleReCaptchaBroker
    {
        ValueTask<GoogleReCaptchaResponse> ValidateCaptchaAsync(string captchaToken, string userIp = "");
    }
}