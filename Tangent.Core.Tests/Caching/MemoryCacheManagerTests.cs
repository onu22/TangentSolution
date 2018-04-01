using NUnit.Framework;
using Tangent.Core.Caching;
using Tangent.Tests;

namespace Tangent.Core.Tests.Caching
{
    [TestFixture]
    public class MemoryCacheManagerTests
    {
        [Test]
        public void Can_set_and_get_object_from_cache()
        {
            var cacheManager = new MemoryCacheManager();
            cacheManager.Set("key_1", 5, int.MaxValue);

            cacheManager.Get<int>("key_1").ShouldEqual(5);
        }

    }
}
