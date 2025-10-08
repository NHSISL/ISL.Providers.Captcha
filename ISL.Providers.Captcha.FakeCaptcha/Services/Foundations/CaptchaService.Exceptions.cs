// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading.Tasks;
using ISL.Providers.Captcha.Abstractions.Models;
using ISL.Providers.Captcha.FakeCaptcha.Models.Foundations.Captcha.Exceptions;
using Xeptions;

namespace ISL.Providers.Captcha.FakeCaptcha.Services.Foundations
{
    internal partial class CaptchaService
    {
        private delegate ValueTask<CaptchaResult> ReturningCaptchaResultFunction();

        private async ValueTask<CaptchaResult> TryCatch(ReturningCaptchaResultFunction returningCaptchaResultFunction)
        {
            try
            {
                return await returningCaptchaResultFunction();
            }
            catch (InvalidArgumentCaptchaException invalidArgumentCaptchaException)
            {
                throw await CreateAndLogValidationExceptionAsync(invalidArgumentCaptchaException);
            }
            catch (Exception exception)
            {
                var failedServiceCaptchaException =
                    new FailedServiceCaptchaException(
                        message: "Failed Captcha service error occurred, please contact support.",
                        innerException: exception,
                        data: exception.Data);

                throw await CreateAndLogServiceExceptionAsync(failedServiceCaptchaException);
            }
        }

        private async ValueTask<CaptchaValidationException> CreateAndLogValidationExceptionAsync(
            Xeption exception)
        {
            var captchaValidationException = new CaptchaValidationException(
                message: "Captcha validation error occurred, please fix the errors and try again.",
                innerException: exception);

            return captchaValidationException;
        }

        private async ValueTask<CaptchaServiceException> CreateAndLogServiceExceptionAsync(
           Xeption exception)
        {
            var captchaServiceException = new CaptchaServiceException(
                message: "Captcha service error occurred, please contact support.",
                innerException: exception);

            return captchaServiceException;
        }
    }
}