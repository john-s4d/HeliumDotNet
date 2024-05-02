using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace HeliumDotNet
{
    public class HeliumApi : IDisposable
    {
        private const string HOST = "api.helium.io";
        private const string VERSION = "1";
        private const string DEFAULT_USERAGENT = "HeliumDotNet";
        private const int LIMIT_DEFAULT = 1000;
        private const int BACKOFF_TIME_MS = 500;

        private HttpClient _httpClient = new HttpClient();
        private bool _disposedValue;

        public HeliumApi() 
            : this(DEFAULT_USERAGENT)
        { }

        public HeliumApi(string userAgent)
        {
            _httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
        }

        #region REST Requests

        private T GetSingle<T>(string route)
        {
            return GetHeliumResponse<T>(GetRequestUri(route)).Data;
        }

        private List<T> GetList<T>(string route, int limit = LIMIT_DEFAULT)
        {
            var initialRequest = GetRequestUri(route);
            HeliumResponse<List<T>> response = GetHeliumResponse<List<T>>(initialRequest);

            List<T> result = response.Data;

            while (response.Cursor != null && result.Count < limit)
            {
                var cursorRequest = new Uri(initialRequest.GetLeftPart(UriPartial.Path) + $"?cursor={UrlEncode(response.Cursor)}");
                response = GetHeliumResponse<List<T>>(cursorRequest);
                result.AddRange(response.Data);
            }
            return result;
        }

        private HeliumResponse<T> GetHeliumResponse<T>(Uri requestUri)
        {
            int delay = BACKOFF_TIME_MS;

            while (true)
            {
                try
                {
                    var response = _httpClient.GetStringAsync(requestUri).Result;
                    return JsonConvert.DeserializeObject<HeliumResponse<T>>(response);
                }
                catch (AggregateException ex)
                {
                    if ((ex.InnerException as HttpRequestException)?.StatusCode == HttpStatusCode.TooManyRequests)
                    {
                        System.Threading.Thread.Sleep(delay);
                        delay += delay;
                        continue;
                    }
                    throw;
                }
            }
        }

        private Uri GetRequestUri(string route)
        {
            return new Uri($"https://{HOST}/v{VERSION}/{route}");
        }

        private object UrlEncode(object value)
        {
            return WebUtility.UrlEncode(value?.ToString());
        }

        #endregion

        #region Hotspots        

        // https://docs.helium.com/api/blockchain/hotspots        

        public List<Hotspot> ListHotspots(string filterModes = null, int limit = LIMIT_DEFAULT)
        {
            // TODO: filterModes could be Enum
            return GetList<Hotspot>($"hotspots?filter_modes={UrlEncode(filterModes)}", limit);
        }

        public Hotspot HotspotForAddress(string address)
        {
            return GetSingle<Hotspot>($"hotspots/{UrlEncode(address)}");
        }

        public List<Hotspot> HotspotsForName(string name, int limit = LIMIT_DEFAULT)
        {
            return GetList<Hotspot>($"hotspots/name/{UrlEncode(name)}", limit);
        }

        public List<Hotspot> HotspotNameSearch(string term, int limit = LIMIT_DEFAULT)
        {
            return string.IsNullOrEmpty(term) ? new List<Hotspot>() : GetList<Hotspot>($"hotspots/name?search={UrlEncode(term)}", limit);
        }

        public List<Hotspot> HotspotLocationDistanceSearch(float latitude, float longitude, int distance, int limit = LIMIT_DEFAULT)
        {
            return GetList<Hotspot>($"hotspots/location/distance?lat={UrlEncode(latitude)}&lon={UrlEncode(longitude)}&distance={UrlEncode(distance)}", limit);
        }

        public List<Hotspot> HotspotLocationBoxSearch(float swLatitude, float swLongitude, float neLatitude, float neLongitude, int limit = LIMIT_DEFAULT)
        {
            return GetList<Hotspot>($"hotspots/location/box?swlat={UrlEncode(swLatitude)}&swlon={UrlEncode(swLongitude)}&nelat={UrlEncode(neLatitude)}&nelon={UrlEncode(neLongitude)}", limit);
        }

        public List<Hotspot> HotspotsForH3Index(string h3Index, int limit = LIMIT_DEFAULT)
        {
            return GetList<Hotspot>($"hotspots/hex/{UrlEncode(h3Index)}", limit);
        }

        public List<Transaction> HotspotActivity(string address, string filterTypes = null, string minTime = null, string maxTime = null, int limit = LIMIT_DEFAULT)
        {
            return GetList<Transaction>($"hotspots/{UrlEncode(address)}/activity?filter_types={UrlEncode(filterTypes)}&min_time={UrlEncode(minTime)}&max_time={UrlEncode(maxTime)}&limit={UrlEncode(limit)}", limit);
        }

        public Dictionary<string, int> HotspotActivityCounts(string address, string filterTypes = null)
        {
            return GetSingle<Dictionary<string, int>>($"hotspots/{UrlEncode(address)}/activity/count?filter_types={UrlEncode(filterTypes)}");
        }

        public List<Election> HotspotElections(string address, string minTime = null, string maxTime = null, int limit = LIMIT_DEFAULT)
        {
            return GetList<Election>($"hotspots/{address}/elections?min_time={minTime}&max_time={maxTime}&limit={limit}", limit);
        }

        public List<Hotspot> CurrentlyElectedHotspots(int limit = LIMIT_DEFAULT)
        {
            // This appears to be depracated.
            return GetList<Hotspot>($"hotspots/elected", limit);
        }
        /*
        public List<Challenge> HotspotChallenges(string address, string minTime = null, string maxTime = null, int limit = LIMIT)
        {
            return GetList<Challenge>($"hotspots/{address}/challenges?min_time={minTime}&max_time={maxTime}&limit={limit}", limit);
        }*/

        public void RewardsForHotspot()
        {
            throw new NotImplementedException();
        }

        public List<RewardSum> RewardTotalForHotspot(string address, string minTime = null, string maxTime = null, string bucket = null)
        {
            return GetList<RewardSum>($"hotspots/{address}/rewards/sum?min_time={minTime}&max_time={maxTime}&bucket={bucket}");
        }

        public void WitnessesForHotspot()
        {
            throw new NotImplementedException();
        }

        public void WitnessedForHotspot()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Elections

        // https://docs.helium.com/api/blockchain/elections

        public List<Election> ListElections(string minTime = null, string maxTime = null, int limit = LIMIT_DEFAULT)
        {
            return GetList<Election>($"elections?min_time={minTime}&max_time={maxTime}&limit={limit}", limit);
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _httpClient.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~HeliumApi()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
