﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Application.ExtensionMethod
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection Services)
        {

             Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return Services;
        }
    }
}
