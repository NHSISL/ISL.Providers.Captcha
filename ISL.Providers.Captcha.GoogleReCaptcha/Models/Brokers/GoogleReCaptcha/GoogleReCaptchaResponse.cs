// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha
{
    public class GoogleReCaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public DateTimeOffset ChallengeTime { get; set; }

        [JsonProperty("apk_package_name")]
        public string ApkPackageName { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
