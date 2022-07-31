using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_test_July22
{
    class OneAssetLoader
    {
        public OneAssetLoader(string ID)
        {
            asset = GetInfo(ID).GetAwaiter().GetResult();
        }
        private static async Task<Assets> GetInfo(string ID)
        {
            var asset = await GetInfoUsingApi.GetAssets(ID);
            return asset;
        }

        public Assets asset { get; set; }
    }
}
