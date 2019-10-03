﻿using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Globalization;
using Sitecore;

namespace Trelleborg.Foundation.Caching
{

    public class CacheManager
    {
        #region Local Variables
        private static CacheManager _instance = null;
        private readonly ApplicationCache _cache = null;
        private readonly string _cacheSize = null;
        #endregion Local Variables

        #region Constructor
        private CacheManager()
        {
            //_cacheSize = !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings[GenericConstants.GlobalCacheSize]) ?
            //                         ConfigurationManager.AppSettings[GenericConstants.GlobalCacheSize] : "500MB";

            //_cache = new ApplicationCache(GenericConstants.GlobalDataCache,
            //     StringUtil.ParseSizeString(_cacheSize));

            _cacheSize = "500MB";

            _cache = new ApplicationCache("GlobalDataCache",
                 StringUtil.ParseSizeString(_cacheSize));
        }

        public static CacheManager CacheManagerInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CacheManager();
                }
                return _instance;
            }
        }

        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Get generic object from cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xCacheKey"></param>
        /// <returns></returns>
        public T GetCache<T>(T xCacheKey)
        {
            T retObj = default(T);
            retObj = (T)_cache.InnerCache.GetValue(xCacheKey?.ToString());
            return retObj;
        }

        /// <summary>
        /// Gets string from cache.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCache(string key)
        {
            return _cache.GetString(key);
        }

        /// <summary>
        /// Setting generic objects into cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xCacheKey"></param>
        /// <param name="xCacheObj"></param>
        /// <param name="xcacheDurationInMinutes"></param>
        /// <returns></returns>
        public Boolean SetCache<T>(String xCacheKey, T xCacheObj, int xcacheDurationInMinutes)
        {
            Boolean bIsSuccess = false;
            if (!_cache.InnerCache.ContainsKey(xCacheKey))
            {
                _cache.InnerCache.Add(xCacheKey, xCacheObj, TimeSpan.FromMinutes(xcacheDurationInMinutes));
            }

            return bIsSuccess;
        }

        /// <summary>
        /// Set String To Cache. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheDurationInMinutes"></param>
        public void SetCache(string key, string value, int cacheDurationInMinutes)
        {
            //set default cache duration
            var timeStamp = RoundUp(DateTime.Now, TimeSpan.FromMinutes(cacheDurationInMinutes));
            _cache.SetString(key, value, timeStamp);
        }

        /// <summary>
        /// Clear all cache.
        /// </summary>
        /// <returns></returns>
        public bool ClearAllCache()
        {
            _cache.Clear();
            return true;
        }

        /// <summary>
        /// Remove cache as per the key.
        /// </summary>
        /// <param name="xCacheKey"></param>
        /// <returns></returns>
        public bool RemoveCache(String xCacheKey)
        {
            _cache.Remove(xCacheKey);
            return true;
        }

        /// <summary>
        /// Get cache keys.
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetCacheKey(string cacheKey, string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
                cacheKey = string.Concat(cacheKey, "_" + id);

            return cacheKey;
        }


        public T GetCacheAsJson<T>(T xCacheKey)
        {

            T retObj = default(T);

            string jsonString = _cache.GetString(xCacheKey?.ToString());
            if (!String.IsNullOrEmpty(jsonString))
            {
                if (typeof(T) == typeof(String))
                    retObj = (T)System.Convert.ChangeType(jsonString, typeof(T), CultureInfo.CurrentCulture);
                else
                    retObj = JsonConvert.DeserializeObject<T>(jsonString);
            }
            return retObj;
        }

        public Boolean SetCacheAsJson<T>(String xCacheKey, T xCacheObj, int xcacheDurationInMinutes)
        {
            string jsonString = string.Empty;
            var timeStamp = RoundUp(DateTime.Now, TimeSpan.FromMinutes(xcacheDurationInMinutes));
            jsonString = typeof(T) != typeof(string) ? JsonConvert.SerializeObject(xCacheObj) : xCacheObj?.ToString();
            _cache.SetString(xCacheKey, jsonString, timeStamp);
            return true;
        }
        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Roundup of Cache duration.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        private static DateTime RoundUp(DateTime dateTime, TimeSpan timeSpan)
        {
            return dateTime.Add(timeSpan);
        }
        #endregion Private Methods
    }

}
