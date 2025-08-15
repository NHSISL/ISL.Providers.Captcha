// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using ISL.Providers.Captcha.GoogleReCaptcha.Providers;
using Microsoft.Extensions.Configuration;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Tests.Integration
{
    public partial class GoogleReCaptchaProviderTests
    {
        private readonly IGoogleReCaptchaProvider googleReCaptchaProvider;
        private readonly GoogleReCaptchaConfigurations googleReCaptchaConfigurations;
        private readonly IConfiguration configuration;

        public GoogleReCaptchaProviderTests()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            configuration = configurationBuilder.Build();

            this.googleReCaptchaConfigurations = configuration
                .GetSection("googleReCaptchaConfigurations").Get<GoogleReCaptchaConfigurations>();

            this.googleReCaptchaProvider = new GoogleReCaptchaProvider(googleReCaptchaConfigurations);
        }
    }
}
