// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;
using ISL.Providers.Captcha.Abstractions.Models;

namespace ISL.Providers.Captcha.FakeCaptcha.Services.Foundations
{
    internal interface ICaptchaService
    {
        ValueTask<CaptchaResult> ValidateCaptchaAsync(string captchaToken, string userIp = "");
    }
}
