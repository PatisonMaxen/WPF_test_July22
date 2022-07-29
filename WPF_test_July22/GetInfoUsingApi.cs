using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WPF_test_July22
{
    class GetInfoUsingApi
    {
        public static async Task<Assets> GetAssets()
        {
            string url = "https://cryptingup.com/api/assets";

            using (HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    Assets assets = await response.Content.ReadAsAsync<Assets>();

                    return assets;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}
