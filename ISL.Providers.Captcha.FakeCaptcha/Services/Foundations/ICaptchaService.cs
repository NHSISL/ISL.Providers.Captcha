// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

namespace ISL.Providers.Captcha.FakeCaptcha.Services.Foundations
{
    internal interface ICaptchaService
    {
        bool ValidateCaptcha(string captchaToken, string userIp = "");
    }
}