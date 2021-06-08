using cangulo.build.Application.Requests;
using cangulo.build.Application.Validators;
using FluentValidation;
using FluentValidation.Results;
using Nuke.Common;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cangulo.Build
{
    public partial class Build : NukeBuild
    {
        private bool ValidateRequest()
        {
            Logger.Info($"RequestJSON received:\n{RequestJSON}");

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            try
            {
                var baseRequest = JsonSerializer.Deserialize<BaseCLIRequest>(RequestJSON, options);

                var baseValidationResult = (new BaseCLIRequestValidator()).Validate(baseRequest);
                if (!baseValidationResult.IsValid)
                {
                    Logger.Error($"Validation Errors:\n");
                    baseValidationResult.Errors.ForEach(x => Logger.Error(x.ErrorMessage));
                    return false;
                }

                var requestType = Type.GetType($"cangulo.build.Application.Requests.{baseRequest.RequestModel}");
                var request = JsonSerializer.Deserialize(RequestJSON, requestType, options);
                Logger.Info($"Request Mapped {requestType.Name}");

                var validatorType = typeof(AbstractValidator<>);
                validatorType = validatorType.MakeGenericType(new Type[] { requestType });
                var validator = _serviceProvider.GetService(validatorType);

                if (validator == null)
                {
                    Request = request as BaseCLIRequest;
                    return true;
                }

                var validationResult = validator
                                        .GetType()
                                        .GetMethods()
                                        .Single(x => x.Name == "Validate" && x.GetParameters().Single().ParameterType == requestType)
                                        .Invoke(validator, new object[] { request }) as ValidationResult;

                if (!validationResult.IsValid)
                {
                    Logger.Error($"Validation Errors:\n");
                    validationResult.Errors.ForEach(x => Logger.Error(x.ErrorMessage));
                }
                else
                    Logger.Success("Request is valid");

                Request = request as BaseCLIRequest;
                return validationResult.IsValid;
            }
            catch (Exception ex)
            {
                Logger.Error("Error Parsing the request \n", ex);
                throw;
            }
        }

        private bool AwsProfileSetup()
        {
            return "ASDASD" == "ASDASD";
        }
    }
}