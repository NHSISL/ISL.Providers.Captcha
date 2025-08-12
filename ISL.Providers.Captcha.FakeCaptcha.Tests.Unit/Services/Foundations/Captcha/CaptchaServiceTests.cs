// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.FakeCaptcha.Services.Foundations;
using Tynamix.ObjectFiller;

namespace ISL.Providers.Captcha.FakeCaptcha.Tests.Unit.Services.Foundations.Captcha
{
    public partial class CaptchaServiceTests
    {
        private readonly ICaptchaService captchaService;

        public CaptchaServiceTests()
        {
            this.captchaService = new CaptchaService();
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
