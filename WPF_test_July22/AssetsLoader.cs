using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_test_July22
{
    class AssetsLoader
    {
        public AssetsLoader()
        {
            assets = GetInfo().GetAwaiter().GetResult();
        }
        private static async Task<Assets> GetInfo()
        {
            var assets = await GetInfoUsingApi.GetAssets();
            return assets;
        }

        public Assets assets { get; set; }
    }
}
