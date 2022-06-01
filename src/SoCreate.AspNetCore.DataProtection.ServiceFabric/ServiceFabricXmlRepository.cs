using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("SoCreate.AspNetCore.DataProtection.Tests")]
namespace SoCreate.AspNetCore.DataProtection.ServiceFabric
{
    class ServiceFabricXmlRepository : IXmlRepository
    {
        private const string CacheKey = "9adfa3b3-3199-4f59-a759-50054bfe161f";
        private readonly IDistributedCache _distributedCache;
        private readonly ISystemClock _systemClock;

        public ServiceFabricXmlRepository(IDistributedCache distributedCache, ISystemClock systemClock = null)
        {
            _distributedCache = distributedCache;
            _systemClock = systemClock ?? new SystemClock();
        }

        public IReadOnlyCollection<XElement> GetAllElements()
        {
            var bytes = _distributedCache.Get(CacheKey) ?? Array.Empty<byte>();
            return GetElementList(Encoding.UTF8.GetString(bytes)).AsReadOnly();
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            var options = new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.MaxValue };

            var bytes = _distributedCache.Get(CacheKey) ?? Array.Empty<byte>();
            var elements = GetElementList(Encoding.UTF8.GetString(bytes));
            elements.Add(element);

            _distributedCache.Set(CacheKey, ConvertElementListToByteArray(elements), options);
        }

        private byte[] ConvertElementListToByteArray(List<XElement> elements)
        {
            var serializer = new XmlSerializer(typeof(List<string>));
            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, elements.Select(e => e.ToString(SaveOptions.DisableFormatting)).ToList());
                return ms.GetBuffer();
            }
        }

        private List<XElement> GetElementList(string value)
        {
            var list = new List<XElement>();
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (value.Contains("\x00"))
                {
                    value = value.Replace("\x00", "");
                }

                var serializer = new XmlSerializer(typeof(List<string>));
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(value)))
                {
                    var elements = (List<string>)(serializer.Deserialize(ms));
                    foreach (var element in elements)
                    {
                        list.Add(XElement.Parse(element));
                    }
                }
            }

            return list;
        }
    }
}
