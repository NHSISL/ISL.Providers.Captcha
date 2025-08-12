// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

namespace ISL.Providers.Captcha.FakeCaptcha.Services.Foundations
{
    internal class CaptchaService : ICaptchaService
    {
        public bool ValidateCaptcha(string captchaToken, string userIp = "")
        {
            if (captchaToken == "valid-captcha")
            {
                return true;
            }

            return false;
        }
    }
}