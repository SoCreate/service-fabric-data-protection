using System.Fabric; 
using SoCreate.Extensions.Caching.ServiceFabric;

namespace DataProtectionStore
{
    internal sealed class DataProtectionStore : DistributedCacheStoreService
    {
        public DataProtectionStore(StatefulServiceContext context)
            : base(context)
        { }
    }
}
