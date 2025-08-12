// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha
{
    internal class CaptchaService : ICaptchaService
    {
        public ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "")
        {
            throw new System.NotImplementedException();
        }
    }
}
