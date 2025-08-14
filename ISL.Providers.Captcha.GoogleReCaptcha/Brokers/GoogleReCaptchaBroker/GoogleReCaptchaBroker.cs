// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

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

        public async ValueTask<GoogleReCaptchaResponse> ValidateCaptchaAsync(string captchaToken, string userIp = "")
        {
            string route = "api/siteverify";

            string path = googleReCaptchaConfigurations.ApiUrl.EndsWith("/")
                ? route
                : $"/{route}";

            var formData = new Dictionary<string, string>
            {
                { "secret", googleReCaptchaConfigurations.ApiSecret },
                { "response", captchaToken },
                { "remoteip", userIp }
            };

            HttpResponseMessage response = await httpClient.PostAsync(route, new FormUrlEncodedContent(formData));
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GoogleReCaptchaResponse>(json);

            return result;
        }

        private HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(uriString: googleReCaptchaConfigurations.ApiUrl),
            };

            return httpClient;
        }
    }
}