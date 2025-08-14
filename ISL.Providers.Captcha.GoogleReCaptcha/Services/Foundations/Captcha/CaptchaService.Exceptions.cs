// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha.Exceptions;
using System;
using System.Threading.Tasks;
using Xeptions;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha
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
            catch (InvalidCaptchaArgumentException invalidCaptchaArgumentException)
            {
                throw await CreateAndLogValidationExceptionAsync(invalidCaptchaArgumentException);
            }
            catch (InvalidCaptchaFormDataException invalidCaptchaFormDataException)
            {
                throw await CreateAndLogValidationExceptionAsync(invalidCaptchaFormDataException);
            }
            catch (Exception exception)
            {
                var failedServiceIdentificationRequestException =
                    new FailedCaptchaServiceException(
                        message: "Failed Captcha service error occurred, please contact support.",
                        innerException: exception,
                        data: exception.Data);

                throw await CreateAndLogServiceExceptionAsync(failedServiceIdentificationRequestException);
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
