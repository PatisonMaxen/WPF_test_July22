using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WPF_test_July22
{
    // Class for DataContext and logic for TOP10 page
    class Top10Fields : INotifyPropertyChanged
    {
        

        public ObservableCollection<Coin> Coins { get; set; }
        public Assets asset;





        public Top10Fields()
        {

            Coins = new ObservableCollection<Coin>();
            GetSearchResult();
        }

        


        public void GetSearchResult()
        {
            asset = GetInfoUsingApi.GetAssets(10);
           
            SaveCoins();
        }

       

        private void SaveCoins()
        {
            Coins.Clear();
            for (int i = 0; i < 10; i++)
            {
                Coins.Add(asset.assets[i]);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}

