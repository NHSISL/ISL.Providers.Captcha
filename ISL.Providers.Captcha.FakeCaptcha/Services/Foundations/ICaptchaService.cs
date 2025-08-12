// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

namespace ISL.Providers.Captcha.FakeCaptcha.Services.Foundations
{
    internal interface ICaptchaService
    {
        ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "");
    }
}
