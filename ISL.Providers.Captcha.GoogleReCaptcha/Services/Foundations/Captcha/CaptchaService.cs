// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ISL.Providers.Captcha.Abstractions.Models;
using ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using Newtonsoft.Json;

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

        public ValueTask<CaptchaResult> ValidateCaptchaAsync(string captchaToken, string userIp = "") =>
            TryCatch(async () =>
            {
                ValidateCaptchaValidationArguments(captchaToken);

                var formData = new Dictionary<string, string>
                {
                    { "secret", googleReCaptchaConfigurations.ApiSecret },
                    { "response", captchaToken },
                    { "remoteip", userIp }
                };

                ValidateFormData(formData);

                HttpResponseMessage googleReCaptchaResponse =
                    await this.googleReCaptchaBroker.ValidateCaptchaAsync(formData);

                googleReCaptchaResponse.EnsureSuccessStatusCode();
                var json = await googleReCaptchaResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GoogleReCaptchaResponse>(json);

                var captchaResult = new CaptchaResult
                {
                    Success = result.Success,
                    Score = result.Score
                };

                return captchaResult;
            });
    }
}
