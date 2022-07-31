using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPF_test_July22
{
    class SearchFields : INotifyPropertyChanged
    {
        private string asset_id;
        private string name;
        private double price;
        private double volume_24h;
        private double change_24h;

        public Assets asset;

        public string Asset_id
        {
            get
            {
                return asset_id;
            }

            set
            {
                asset_id = value;
                OnPropertyChanged("Asset_id");
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public double Volume_24h
        {
            get
            {
                return volume_24h;
            }

            set
            {
                volume_24h = value;
                OnPropertyChanged("Volume_24h");
            }
        }


        public double Change_24h
        {
            get
            {
                return change_24h;
            }

            set
            {
                change_24h = value;
                OnPropertyChanged("Change_24h");
            }
        }

        public void GetSearchResult(string ID)
        {
            asset = GetInfo(ID).GetAwaiter().GetResult();
            Asset_id = asset.asset.asset_id;
            Name = asset.asset.name;
            Price = asset.asset.price;
            Volume_24h = asset.asset.volume_24h;
            Change_24h = asset.asset.change_24h;
        }

        private static async Task<Assets> GetInfo(string ID)
        {
            var asset = await GetInfoUsingApi.GetAssets(ID);
            return asset;
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
