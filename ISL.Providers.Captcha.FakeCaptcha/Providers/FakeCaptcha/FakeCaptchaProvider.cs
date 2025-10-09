// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading.Tasks;
using ISL.Providers.Captcha.Abstractions.Models;
using ISL.Providers.Captcha.FakeCaptcha.Models.Foundations.Captcha.Exceptions;
using ISL.Providers.Captcha.FakeCaptcha.Models.Providers.Exceptions;
using ISL.Providers.Captcha.FakeCaptcha.Services.Foundations;
using Microsoft.Extensions.DependencyInjection;
using Xeptions;

namespace ISL.Providers.Captcha.FakeCaptcha.Providers.FakeCaptcha
{
    public class FakeCaptchaProvider : IFakeCaptchaProvider
    {
        private ICaptchaService captchaService { get; set; }

        public FakeCaptchaProvider()
        {
            IServiceProvider serviceProvider = RegisterServices();
            InitializeClients(serviceProvider);
        }

        /// <summary>
        /// Uses Captcha service to validate a user request given a captcha token and user IP
        /// </summary>
        /// <returns>
        /// A captcha result object containing a bool indicating whether the validation was successful and a score of
        /// how likely the user is a human
        /// </returns>
        /// <exception cref="FakeCaptchaValidationProviderException" />
        /// <exception cref="FakeCaptchaDependencyValidationProviderException" />
        /// <exception cref="FakeCaptchaDependencyProviderException" />
        /// <exception cref="FakeCaptchaServiceProviderException" />
        public async ValueTask<CaptchaResult> ValidateCaptchaAsync(string captchaToken, string userIp = "")
        {
            try
            {
                return await captchaService.ValidateCaptchaAsync(captchaToken, userIp);
            }
            catch (CaptchaValidationException captchaValidationException)
            {
                throw CreateProviderValidationException(
                    captchaValidationException.InnerException as Xeption);
            }
            catch (CaptchaDependencyValidationException captchaDependencyValidationException)
            {
                throw CreateProviderDependencyValidationException(
                    captchaDependencyValidationException.InnerException as Xeption);
            }
            catch (CaptchaDependencyException captchaDependencyException)
            {
                throw CreateProviderDependencyException(
                    captchaDependencyException.InnerException as Xeption);
            }
            catch (CaptchaServiceException captchaServiceException)
            {
                throw CreateProviderServiceException(
                    captchaServiceException.InnerException as Xeption);
            }
        }

        private static FakeCaptchaProviderValidationException CreateProviderValidationException(
            Xeption innerException)
        {
            return new FakeCaptchaProviderValidationException(
                message: innerException.Message,
                innerException,
                data: innerException.Data);
        }

        private static FakeCaptchaProviderDependencyValidationException CreateProviderDependencyValidationException(
            Xeption innerException)
        {
            return new FakeCaptchaProviderDependencyValidationException(
                message: innerException.Message,
                innerException,
                data: innerException.Data);
        }

        private static FakeCaptchaProviderDependencyException CreateProviderDependencyException(
            Xeption innerException)
        {
            return new FakeCaptchaProviderDependencyException(
                message: innerException.Message,
                innerException);
        }

        private static FakeCaptchaProviderServiceException CreateProviderServiceException(Xeption innerException)
        {
            return new FakeCaptchaProviderServiceException(
                message: innerException.Message,
                innerException);
        }

        private void InitializeClients(IServiceProvider serviceProvider) =>
            this.captchaService = serviceProvider.GetRequiredService<ICaptchaService>();

        private static IServiceProvider RegisterServices()
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<ICaptchaService, CaptchaService>();

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
