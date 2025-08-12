// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.FakeCaptcha.Models.Foundations.Captcha.Exceptions;
using System;
using System.Threading.Tasks;
using Xeptions;

namespace ISL.Providers.Captcha.FakeCaptcha.Services.Foundations
{
    internal partial class CaptchaService
    {
        private delegate ValueTask<bool> ReturningBoolFunction();

        private async ValueTask<bool> TryCatch(ReturningBoolFunction returningBoolFunction)
        {
            try
            {
                return await returningBoolFunction();
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