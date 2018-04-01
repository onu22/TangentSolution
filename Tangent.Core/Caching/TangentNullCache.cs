using System;
using System.Collections.Generic;
using System.Text;

namespace Tangent.Core.Caching
{
    public partial class TangentNullCache : ICacheManager
    {
        public virtual T Get<T>(string key)
        {
            return default(T);
        }

        public virtual void Set(string key, object data, int cacheTime)
        {
        }

        public bool IsSet(string key)
        {
            return false;
        }

        public virtual void Remove(string key)
        {
        }
        public virtual void Clear()
        {
        }
    }
}
