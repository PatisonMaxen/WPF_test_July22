using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WPF_test_July22
{
    // Main class for getting info via API
    static class GetInfoUsingApi
    {
        public static Assets GetAssets(int size)
        {
            string url = "https://cryptingup.com/api/assets?size=" + size;

            return GetInfo<Assets>(url).GetAwaiter().GetResult();

        }

        public static Assets GetOneAsset(string ID)
        {
            string url = "https://cryptingup.com/api/assets/" + ID.ToUpper();

            return GetInfo<Assets>(url).GetAwaiter().GetResult();
            
            
        }
        public static Assets GetNamesIDs()
        {

            string url = "https://cryptingup.com/api/assetsoverview";

            return GetInfo<Assets>(url).GetAwaiter().GetResult();

           
        }

        public static Markets GetMarkets(string ID)
        {
            string url = $"https://cryptingup.com/api/assets/{ID}/markets";

            return GetInfo<Markets>(url).GetAwaiter().GetResult();
        }

        
        // Internal method for doing calls
        private static async Task<T> DoCall<T>(string url)
        {
            using (HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).Result)
            {
                T result;
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsAsync<T>();

                    return (T)Convert.ChangeType(result, typeof(T));
                }
                else
                {
                    return (T)Convert.ChangeType(null, typeof(T));
                }
            }
        }
        private static async Task<T> GetInfo<T>(string url)
        {
            var result = await DoCall<T>(url);
            return (T)Convert.ChangeType(result, typeof(T));
        }
    }

   


}
