// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker
{
    internal class GoogleReCaptchaBroker : IGoogleReCaptchaBroker
    {
        private readonly GoogleReCaptchaConfigurations googleReCaptchaConfigurations;
        private readonly HttpClient httpClient;

        public GoogleReCaptchaBroker(GoogleReCaptchaConfigurations googleReCaptchaConfigurations)
        {
            this.googleReCaptchaConfigurations = googleReCaptchaConfigurations;
            httpClient = SetupHttpClient();
        }

        public async ValueTask<HttpResponseMessage> ValidateCaptchaAsync(Dictionary<string, string> formData)
        {
            string route = googleReCaptchaConfigurations.ApiRoute;

            string path = googleReCaptchaConfigurations.ApiBaseUrl.EndsWith("/")
                ? route
                : $"/{route}";

            return await httpClient.PostAsync(path, new FormUrlEncodedContent(formData));
        }

        private HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(uriString: googleReCaptchaConfigurations.ApiBaseUrl),
            };

            return httpClient;
        }
    }
}