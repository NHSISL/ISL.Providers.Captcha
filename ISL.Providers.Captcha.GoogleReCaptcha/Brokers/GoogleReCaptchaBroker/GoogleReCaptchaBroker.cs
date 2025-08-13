// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using RESTFulSense.Clients;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker
{
    internal class GoogleReCaptchaBroker : IGoogleReCaptchaBroker
    {
        private readonly GoogleReCaptchaConfigurations googleReCaptchaConfigurations;
        private readonly IRESTFulApiFactoryClient apiClient;
        private readonly HttpClient httpClient;

        public GoogleReCaptchaBroker(GoogleReCaptchaConfigurations googleReCaptchaConfigurations)
        {
            this.googleReCaptchaConfigurations = googleReCaptchaConfigurations;
            httpClient = SetupHttpClient();
            apiClient = SetupApiClient();
        }

        public async ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "")
        {
            string route = "/api/siteverify";

            string path = googleReCaptchaConfigurations.ApiUrl.EndsWith("/")
                ? route
                : $"/{route}";

            var request = new GoogleReCaptchaRequest
            {
                ApiSecret = googleReCaptchaConfigurations.ApiSecret,
                CaptchaToken = captchaToken,
                UserIp = userIp
            };

            GoogleReCaptchaResponse response = 
                await apiClient.PostContentAsync<GoogleReCaptchaRequest, GoogleReCaptchaResponse>(route, request);

            return response.Success;
        }

        private HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(uriString: googleReCaptchaConfigurations.ApiUrl),
            };

            return httpClient;
        }

        private IRESTFulApiFactoryClient SetupApiClient() =>
            new RESTFulApiFactoryClient(httpClient);
    }
}
