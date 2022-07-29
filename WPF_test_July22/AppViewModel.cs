using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_test_July22
{
     class AppViewModel : INotifyPropertyChanged
    {
       
        
        public AppViewModel()
        {
            assets = GetInfo().GetAwaiter().GetResult();
            double n = 2.55569;
            
        }

        private static async Task<Assets> GetInfo()
        {
            var assets = await GetInfoUsingApi.GetAssets();
            return assets;
        }

        public Assets assets { get; set; }

        public string nice { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
