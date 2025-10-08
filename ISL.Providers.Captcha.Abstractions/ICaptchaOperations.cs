// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;
using ISL.Providers.Captcha.Abstractions.Models;

namespace ISL.Providers.Captcha.Abstractions
{
    public interface ICaptchaOperations
    {
        /// <summary>
        /// Uses Captcha service to validate a user request given a captcha token and user IP
        /// </summary>
        /// <returns>
        /// A captcha result object containg a bool indicating whether the validation was successful and a score of
        /// how likely the user is a human
        /// </returns>
        ValueTask<CaptchaResult> ValidateCaptchaAsync(string captchaToken, string userIp = "");
    }
}
