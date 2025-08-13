// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha
{
    public class GoogleReCaptchaRequest
    {
        public string ApiSecret { get; set; }
        public string CaptchaToken { get; set; }
        public string UserIp { get; set; } = String.Empty;
    }
}
