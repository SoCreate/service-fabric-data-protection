using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace SoCreate.AspNetCore.DataProtection.ServiceFabric
{
    class ConfigureKeyManagementOptions : IConfigureOptions<KeyManagementOptions>
    {
        private readonly IDistributedCache _distributedCache;

        public ConfigureKeyManagementOptions(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Configure(KeyManagementOptions options)
        {
            options.XmlRepository = new ServiceFabricXmlRepository(_distributedCache);
        }
    }
}
