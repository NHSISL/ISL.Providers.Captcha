// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers;
using System.Threading.Tasks;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha
{
    internal partial class CaptchaService : ICaptchaService
    {
        private readonly IGoogleReCaptchaBroker googleReCaptchaBroker;
        private readonly GoogleReCaptchaConfigurations googleReCaptchaConfigurations;

        public CaptchaService(
            IGoogleReCaptchaBroker googleReCaptchaBroker, GoogleReCaptchaConfigurations googleReCaptchaConfigurations)
        {
            this.googleReCaptchaBroker = googleReCaptchaBroker;
            this.googleReCaptchaConfigurations = googleReCaptchaConfigurations;
        }

        public ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "") =>
            TryCatch(async () =>
            {
                ValidateCaptchaValidationArguments(captchaToken);

                return await this.googleReCaptchaBroker.ValidateCaptchaAsync(captchaToken, userIp);
            });
    }
}
