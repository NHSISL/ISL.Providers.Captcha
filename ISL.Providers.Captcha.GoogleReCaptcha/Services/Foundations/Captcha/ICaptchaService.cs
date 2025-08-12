// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha
{
    internal interface ICaptchaService
    {
        ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "");
    }
}
