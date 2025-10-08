// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading.Tasks;
using ISL.Providers.Captcha.Abstractions.Models;
using ISL.Providers.Captcha.Abstractions.Models.Exceptions;
using Xeptions;

namespace ISL.Providers.Captcha.Abstractions
{
    public partial class CaptchaAbstractionProvider
    {
        private delegate ValueTask<CaptchaResult> ReturningCaptchaResultFunction();

        private async ValueTask<CaptchaResult> TryCatch(
            ReturningCaptchaResultFunction returningCaptchaResultFunction)
        {
            try
            {
                return await returningCaptchaResultFunction();
            }
            catch (Xeption ex) when (ex is ICaptchaProviderValidationException)
            {
                throw CreateValidationException(ex);
            }
            catch (Xeption ex) when (ex is ICaptchaProviderDependencyValidationException)
            {
                throw CreateValidationException(ex);
            }
            catch (Xeption ex) when (ex is ICaptchaProviderDependencyException)
            {
                throw CreateDependencyException(ex);
            }
            catch (Xeption ex) when (ex is ICaptchaProviderServiceException)
            {
                throw CreateServiceException(ex);
            }
            catch (Exception ex)
            {
                var uncatagorizedCaptchaProviderException =
                    new UncatagorizedCaptchaProviderException(
                        message: "Captcha provider not properly implemented. Uncatagorized errors found, " +
                            "contact the captcha provider owner for support.",
                        innerException: ex,
                        data: ex.Data);

                throw CreateUncatagorizedServiceException(uncatagorizedCaptchaProviderException);
            }
        }

        private CaptchaProviderValidationException CreateValidationException(Xeption exception)
        {
            var CaptchaProviderValidationException =
                new CaptchaProviderValidationException(
                    message: "Captcha validation errors occurred, please try again.",
                    innerException: exception,
                    data: exception.Data);

            return CaptchaProviderValidationException;
        }

        private CaptchaProviderDependencyException CreateDependencyException(Xeption exception)
        {
            var CaptchaProviderDependencyException = new CaptchaProviderDependencyException(
                message: "Captcha dependency error occurred, contact support.",
                innerException: exception,
                data: exception.Data);

            return CaptchaProviderDependencyException;
        }

        private CaptchaProviderServiceException CreateServiceException(Xeption exception)
        {
            var CaptchaProviderServiceException = new CaptchaProviderServiceException(
                message: "Captcha service error occurred, contact support.",
                innerException: exception,
                data: exception.Data);

            return CaptchaProviderServiceException;
        }

        private CaptchaProviderServiceException CreateUncatagorizedServiceException(Exception exception)
        {
            var CaptchaProviderServiceException = new CaptchaProviderServiceException(
                message: "Uncatagorized captcha service error occurred, contact support.",
                innerException: exception as Xeption,
                data: exception.Data);

            return CaptchaProviderServiceException;
        }
    }
}
