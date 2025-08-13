// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers;
using System.Threading.Tasks;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha
{
    internal class CaptchaService : ICaptchaService
    {
        private readonly IGoogleReCaptchaBroker googleReCaptchaBroker;
        private readonly GoogleReCaptchaConfigurations googleReCaptchaConfigurations;

        public CaptchaService(
            IGoogleReCaptchaBroker googleReCaptchaBroker, GoogleReCaptchaConfigurations googleReCaptchaConfigurations)
        {
            this.googleReCaptchaBroker = googleReCaptchaBroker;
            this.googleReCaptchaConfigurations = googleReCaptchaConfigurations;
        }

        public async ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "")
        {
            return await this.googleReCaptchaBroker.ValidateCaptchaAsync(captchaToken, userIp);
        }
    }
}
