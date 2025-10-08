// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading.Tasks;
using ISL.Providers.Captcha.Abstractions.Models;
using ISL.Providers.Captcha.GoogleReCaptcha.Brokers.GoogleReCaptchaBroker;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Providers.Exceptions;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha.Exceptions;
using ISL.Providers.Captcha.GoogleReCaptcha.Services.Foundations.Captcha;
using Microsoft.Extensions.DependencyInjection;
using Xeptions;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Providers
{
    public class GoogleReCaptchaProvider : IGoogleReCaptchaProvider
    {
        private ICaptchaService captchaService { get; set; }

        public GoogleReCaptchaProvider(GoogleReCaptchaConfigurations configurations)
        {
            IServiceProvider serviceProvider = RegisterServices(configurations);
            InitializeClients(serviceProvider);
        }

        /// <summary>
        /// Uses Captcha service to validate a user request given a captcha token and user IP
        /// </summary>
        /// <returns>
        /// A captcha result object containg a bool indicating whether the validation was successful and a score of
        /// how likely the user is a human
        /// </returns>
        /// <exception cref="GoogleReCaptchaProviderValidationException" />
        /// <exception cref="GoogleReCaptchaProviderDependencyValidationException" />
        /// <exception cref="GoogleReCaptchaProviderDependencyException" />
        /// <exception cref="GoogleReCaptchaProviderServiceException" />
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

        private static GoogleReCaptchaProviderValidationException CreateProviderValidationException(
            Xeption innerException)
        {
            return new GoogleReCaptchaProviderValidationException(
                message: "Google ReCaptcha provider validation error occurred, fix errors and try again.",
                innerException,
                data: innerException.Data);
        }

        private static GoogleReCaptchaProviderDependencyValidationException CreateProviderDependencyValidationException(
            Xeption innerException)
        {
            return new GoogleReCaptchaProviderDependencyValidationException(
                message: "Google ReCaptcha provider dependency validation error occurred, fix errors and try again.",
                innerException,
                data: innerException.Data);
        }

        private static GoogleReCaptchaProviderDependencyException CreateProviderDependencyException(
            Xeption innerException)
        {
            return new GoogleReCaptchaProviderDependencyException(
                message: "Google ReCaptcha provider dependency error occurred, contact support.",
                innerException);
        }

        private static GoogleReCaptchaProviderServiceException CreateProviderServiceException(Xeption innerException)
        {
            return new GoogleReCaptchaProviderServiceException(
                message: "Google ReCaptcha provider service error occurred, contact support.",
                innerException);
        }

        private void InitializeClients(IServiceProvider serviceProvider) =>
            this.captchaService = serviceProvider.GetRequiredService<ICaptchaService>();

        private static IServiceProvider RegisterServices(GoogleReCaptchaConfigurations configurations)
        {
            var serviceCollection = new ServiceCollection()
                .AddTransient<IGoogleReCaptchaBroker, GoogleReCaptchaBroker>()
                .AddTransient<ICaptchaService, CaptchaService>()
                .AddSingleton(configurations);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
