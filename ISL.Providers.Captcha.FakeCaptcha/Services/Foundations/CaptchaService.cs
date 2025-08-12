// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

namespace ISL.Providers.Captcha.FakeCaptcha.Services.Foundations
{
    internal partial class CaptchaService : ICaptchaService
    {
        public ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "") =>
            TryCatch(async () =>
            {
                ValidateCaptchaValidationArguments(captchaToken);

                if (captchaToken == "valid-captcha")
        {
                    return true;
        }

                return false;
            });
    }
}
