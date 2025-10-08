// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;
using ISL.Providers.Captcha.Abstractions.Models;

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
        /// A captcha result object containing a bool indicating whether the validation was successful and a score of
        /// how likely the user is a human
        /// </returns>
        /// <exception cref="CaptchaValidationProviderException" />
        /// <exception cref="CaptchaDependencyProviderException" />
        /// <exception cref="CaptchaServiceProviderException" />
        public ValueTask<CaptchaResult> ValidateCaptchaAsync(string captchaToken, string userIp = "") =>
        TryCatch(async () =>
        {
            return await this.captchaProvider.ValidateCaptchaAsync(captchaToken, userIp);
        });
    }
}
