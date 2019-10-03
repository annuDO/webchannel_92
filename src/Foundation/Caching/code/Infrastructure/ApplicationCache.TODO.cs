using Sitecore.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trelleborg.Foundation.Caching
{ 
    public class ApplicationCache : CustomCache
    {
        public ApplicationCache(string name, long maxSize) : base(name, maxSize)
        {

        }

        public new void SetString(string key, string value, DateTime expirationTime)
        {
            base.SetString(key, value, expirationTime);
        }

        public new string GetString(string key) 
        {
            return base.GetString(key);
        }
    }
}
