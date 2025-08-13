// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker
{
    internal interface IGoogleReCaptchaBroker
    {
        ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "");
    }
}
