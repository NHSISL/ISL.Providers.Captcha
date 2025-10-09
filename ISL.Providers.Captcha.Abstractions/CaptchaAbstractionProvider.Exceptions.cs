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
            catch (Xeption exception) when (exception is ICaptchaProviderValidationException)
            {
                throw CreateValidationException(exception);
            }
            catch (Xeption exception) when (exception is ICaptchaProviderDependencyValidationException)
            {
                throw CreateValidationException(exception);
            }
            catch (Xeption exception) when (exception is ICaptchaProviderDependencyException)
            {
                throw CreateDependencyException(exception);
            }
            catch (Xeption exception) when (exception is ICaptchaProviderServiceException)
            {
                throw CreateServiceException(exception);
            }
            catch (Exception exception)
            {
                throw CreateUncatagorizedServiceException(exception);
            }
        }

        private CaptchaProviderValidationException CreateValidationException(Xeption exception)
        {
            var CaptchaProviderValidationException =
                new CaptchaProviderValidationException(
                    message: exception.Message,
                    innerException: exception,
                    data: exception.Data);

            return CaptchaProviderValidationException;
        }

        private CaptchaProviderDependencyException CreateDependencyException(Xeption exception)
        {
            var CaptchaProviderDependencyException = new CaptchaProviderDependencyException(
                message: exception.Message,
                innerException: exception,
                data: exception.Data);

            return CaptchaProviderDependencyException;
        }

        private CaptchaProviderServiceException CreateServiceException(Xeption exception)
        {
            var CaptchaProviderServiceException = new CaptchaProviderServiceException(
                message: exception.Message,
                innerException: exception,
                data: exception.Data);

            return CaptchaProviderServiceException;
        }

        private CaptchaProviderServiceException CreateUncatagorizedServiceException(Exception exception)
        {
            var CaptchaProviderServiceException = new CaptchaProviderServiceException(
                message: "Captcha provider not properly implemented. Uncatagorized errors found, " +
                    "contact the captcha provider owner for support.",

                innerException: exception as Xeption,
                data: exception.Data);

            return CaptchaProviderServiceException;
        }
    }
}
