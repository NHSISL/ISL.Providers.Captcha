// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Tests.Unit.Services.Foundations.Captcha
{
    public partial class CaptchaServiceTests
    {
        private readonly Mock<IGoogleReCaptchaBroker> googleReCaptchaBroker = new Mock<IGoogleReCaptchaBroker>();
        private GoogleReCaptchaConfigurations googleReCaptchaConfigurations;
        private readonly ICaptchaService captchaService;

        public CaptchaServiceTests()
        {
            this.googleReCaptchaBroker = new Mock<IGoogleReCaptchaBroker>();
            this.googleReCaptchaConfigurations = new GoogleReCaptchaConfigurations
            {
                ApiUrl = GetRandomString(),
                ApiSecret = GetRandomString()
            };

            this.captchaService = new CaptchaService(
                googleReCaptchaBroker: this.googleReCaptchaBroker.Object,
                googleReCaptchaConfigurations: googleReCaptchaConfigurations);
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static bool GetRandomBoolean()
        {
            var random = new Random();

            return random.Next() > (Int32.MaxValue / 2);
        }

        private static Dictionary<string, string> CreateRandomFormData(string secret, string captchaToken)
        {
            var formData = new Dictionary<string, string>
                {
                    { "secret", secret },
                    { "response", captchaToken },
                    { "remoteip", string.Empty }
                };

            return formData;
        }

        private static HttpResponseMessage CreateHttpRepsonseMessage()
        {
            var response = new GoogleReCaptchaResponse
            {
                ChallengeTime = DateTimeOffset.UtcNow,
                Hostname = GetRandomString(),
                Success = GetRandomBoolean()
            };

            var json = JsonConvert.SerializeObject(response);

            var httpResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            return httpResponse;
        }

        private static async ValueTask<bool> GetSuccessFromHttpResponse(HttpResponseMessage httpResponse)
        {
            var json = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GoogleReCaptchaResponse>(json);

            return result.Success;
        }
    }
}
