// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

namespace ISL.Providers.Captcha.Abstractions
{
    public partial class CaptchaAbstractionProvider : ICaptchaAbstractionProvider
    {
        private readonly ICaptchaProvider captchaProvider;

        public CaptchaAbstractionProvider(ICaptchaProvider captchaProvider) =>
            this.captchaProvider = captchaProvider;

        /// <summary>
        /// Uses Captcha service to validate a user request given a captcha token and user IP
        /// </summary>
        /// <returns>
        /// A bool to signify whether the validation was successful
        /// </returns>
        /// <exception cref="CaptchaValidationProviderException" />
        /// <exception cref="CaptchaDependencyProviderException" />
        /// <exception cref="CaptchaServiceProviderException" />
        public ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "") =>
        TryCatch(async () =>
        {
            return await this.captchaProvider.ValidateCaptchaAsync(captchaToken, userIp);
        });
    }
}
