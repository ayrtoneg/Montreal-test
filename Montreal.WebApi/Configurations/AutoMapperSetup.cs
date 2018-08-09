﻿using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Montreal.WebApi.Configurations
{
    public static class AutoMapperSetup
    {
        public static object AutoMapperConfig { get; private set; }

        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            Application.AutoMapper.AutoMapperConfig.RegisterMappings();
        }
    }
}
