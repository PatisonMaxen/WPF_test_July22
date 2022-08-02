using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_test_July22
{
    // Basic class for storing currency's info
    class Coin : INotifyPropertyChanged
    {

        public string asset_id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public double volume_24h { get; set; }
        public double change_24h { get; set; }

        public RealCurrencies quote { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
