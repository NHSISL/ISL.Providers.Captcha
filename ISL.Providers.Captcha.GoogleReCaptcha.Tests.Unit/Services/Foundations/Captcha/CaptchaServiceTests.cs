// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha;
using Moq;
using System;
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

        private static GoogleReCaptchaResponse CreateGoogleReCaptchaResponse() =>
            CreateGoogleReCaptchaResponseFiller().Create();

        private static Filler<GoogleReCaptchaResponse> CreateGoogleReCaptchaResponseFiller()
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.UtcNow;
            var filler = new Filler<GoogleReCaptchaResponse>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dateTimeOffset);

            return filler;
        }
    }
}
