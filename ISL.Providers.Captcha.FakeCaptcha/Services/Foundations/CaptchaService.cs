// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;
using ISL.Providers.Captcha.Abstractions.Models;

namespace ISL.Providers.Captcha.FakeCaptcha.Services.Foundations
{
    internal partial class CaptchaService : ICaptchaService
    {
        public ValueTask<CaptchaResult> ValidateCaptchaAsync(string captchaToken, string userIp = "") =>
            TryCatch(async () =>
            {
                ValidateCaptchaValidationArguments(captchaToken);

                if (captchaToken == "valid-captcha")
                {
                    return new CaptchaResult
                    {
                        IsCaptchaValid = true,
                        Score = 1.0
                    };
                }

                return new CaptchaResult
                {
                    IsCaptchaValid = false,
                    Score = 0.0
                };
            });
    }
}
