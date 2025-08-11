// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;

namespace ISL.Providers.Captcha.Abstractions
{
    public interface ICaptchaOperations
    {
        /// <summary>
        /// Uses Captcha service to validate a user request given a captcha token and user IP
        /// </summary>
        /// <returns>
        /// A bool to signify whether the validation was successful
        /// </returns>
        ValueTask<bool> ValidateCaptchaAsync(string captchaToken, string userIp = "");
    }
}
