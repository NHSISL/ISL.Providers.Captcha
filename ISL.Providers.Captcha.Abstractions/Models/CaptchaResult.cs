// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

namespace ISL.Providers.Captcha.Abstractions.Models
{
    public class CaptchaResult
    {
        public bool IsCaptchaValid { get; set; }
        public double Score { get; set; }
    }
}
