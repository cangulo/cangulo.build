using cangulo.build.Abstractions.Models;
using cangulo.build.Abstractions.NukeLogger;
using cangulo.build.Application.RequestHandlers;
using cangulo.build.Application.Requests;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace cangulo.Build
{
    public static class Startup
    {
        public static ServiceProvider RegisterServices(BuildContext buildContext)
        {
            var services = new ServiceCollection();

            services
                .AddSingleton<BuildContext>(buildContext)
                .AddSingleton<INukeLogger, NukeLogger>();

            services.AddMediatR(typeof(Startup));
            services
                .AddTransient<ICLIRequestHandler<ExecuteUnitTests>, ExecuteUnitTestsRequestHandler>()
                .AddTransient<ICLIRequestHandler<PackProjects>, PackProjectRequestHandler>();

            RegisterApplitactionLayerValidators(services);
            RegisterDomainLayerServices(services);

            return services.BuildServiceProvider(true);
        }

        private static void RegisterApplitactionLayerValidators(ServiceCollection services) => services.Scan(s => s
                        .FromAssemblyOf<CLIRequest>()
                        // Validators
                        .AddClasses(s =>
                            s.AssignableTo(typeof(AbstractValidator<>)))
                        .As((x) =>
                        {
                            var requestType = x.BaseType.GenericTypeArguments[0];
                            var validatorType = typeof(AbstractValidator<>);
                            return new List<Type>() { validatorType.MakeGenericType(new Type[] { requestType }) };
                        })
        );

        private static void RegisterDomainLayerServices(ServiceCollection services) => services.Scan(s => s
                .FromAssemblyOf<CLIRequest>()
                // DomainServices
                .AddClasses(s =>
                    s.Where(x => x.Namespace.Contains("cangulo.build.Domain.Services")))
                .AsImplementedInterfaces()
        );
    }
}
