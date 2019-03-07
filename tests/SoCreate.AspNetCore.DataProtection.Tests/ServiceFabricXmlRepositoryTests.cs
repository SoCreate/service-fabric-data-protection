using AutoFixture.Xunit2;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using SoCreate.AspNetCore.DataProtection.ServiceFabric;
using Xunit;
using System.Linq;
using System.Xml.Linq;

namespace SoCreate.AspNetCore.DataProtection.Tests
{
    public class ServiceFabricXmlRepositoryTests
    {
        [Theory, AutoMoqData]
        void StoreElement_StoreElementSingleElement_ElementStoredIsInListOfElements(
            [Frozen]Mock<IDistributedCache> distributedCache,
            ServiceFabricXmlRepository xmlRepository)
        {
            byte[] cachedValue = null;

            distributedCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<DistributedCacheEntryOptions>())).Callback((string key, byte[] value, DistributedCacheEntryOptions o) => { cachedValue = value; });
            distributedCache.Setup(m => m.Get(It.IsAny<string>())).Returns(() => cachedValue);

            xmlRepository.StoreElement(new XElement("Element1"), null);

            Assert.Equal("<Element1 />", xmlRepository.GetAllElements().First().ToString());
        }

        [Theory, AutoMoqData]
        void StoreElement_StoreElementMultipleElements_AllItemsAreFoundInList(
            [Frozen]Mock<IDistributedCache> distributedCache,
            ServiceFabricXmlRepository xmlRepository)
        {
            byte[] cachedValue = null;

            distributedCache.Setup(m => m.Set(It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<DistributedCacheEntryOptions>())).Callback((string key, byte[] value, DistributedCacheEntryOptions o) => { cachedValue = value; });
            distributedCache.Setup(m => m.Get(It.IsAny<string>())).Returns(() => cachedValue);

            xmlRepository.StoreElement(new XElement("Element1"), null);
            xmlRepository.StoreElement(new XElement("Element2"), null);

            Assert.Equal("<Element1 /><Element2 />", string.Join("", xmlRepository.GetAllElements().Select(e => e.ToString())));
        }
    }
}
