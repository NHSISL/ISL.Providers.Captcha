// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using ISL.Providers.Captcha.GoogleReCaptcha.Providers;
using Microsoft.Extensions.Configuration;
using Tynamix.ObjectFiller;
using WireMock.Server;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Tests.Acceptance
{
    public partial class GoogleReCaptchaProviderTests
    {
        private readonly IGoogleReCaptchaProvider googleReCaptchaProvider;
        private readonly GoogleReCaptchaConfigurations googleReCaptchaConfigurations;
        private readonly WireMockServer wireMockServer;
        private readonly IConfiguration configuration;

        public GoogleReCaptchaProviderTests()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            configuration = configurationBuilder.Build();
            this.wireMockServer = WireMockServer.Start();

            this.googleReCaptchaConfigurations = configuration
                .GetSection("googleReCaptchaConfigurations").Get<GoogleReCaptchaConfigurations>();

            googleReCaptchaConfigurations.ApiBaseUrl = wireMockServer.Url;
            googleReCaptchaConfigurations.ApiRoute = "api/siteverify";

            this.googleReCaptchaProvider = new GoogleReCaptchaProvider(googleReCaptchaConfigurations);
        }

        private static int GetRandomNumber() =>
             new IntRange(min: 2, max: 10).GetValue();

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static GoogleReCaptchaResponse CreateRandomGoogleReCaptchaResponse()
        {
            return CreateGoogleRecaptchaResponseFiller().Create();
        }

        private static Filler<GoogleReCaptchaResponse> CreateGoogleRecaptchaResponseFiller()
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow;
            var filler = new Filler<GoogleReCaptchaResponse>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dateTimeOffset);

            return filler;
        }
    }
}
