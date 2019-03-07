using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SoCreate.AspNetCore.DataProtection.ServiceFabric;
using SoCreate.Extensions.Caching.ServiceFabric;
using System;

namespace Microsoft.AspNetCore.DataProtection
{
    public static class ServiceFabricDataProtectionBuilderExtensions
    {
        public static IDataProtectionBuilder PersistKeysToServiceFabricDistributedCache(this IDataProtectionBuilder builder, Action<ServiceFabricCacheOptions> setupAction = null)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Services.AddDistributedServiceFabricCache(setupAction);
            builder.Services.AddSingleton<IConfigureOptions<KeyManagementOptions>, ConfigureKeyManagementOptions>();

            return builder;
        }
    }
}
