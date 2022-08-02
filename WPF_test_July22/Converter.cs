using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace WPF_test_July22
{
    // Class for bindind as DataContext to Converter page
    class Converter : INotifyPropertyChanged
    {
        private string baseCurrency;
        private string convertToCurrency;
        private string valueToConvert;
        private string result;

        private Assets namesIDs;

        public Converter()
        {
            namesIDs = GetInfoUsingApi.GetNamesIDs();
        }

        public string BaseCurrency
        {
            get
            {
                return baseCurrency;
            }
            set
            {
                baseCurrency = value;
                OnPropertyChanged("BaseCurrency");
            }
        }

        public string ConvertToCurrency
        {
            get
            {
                return convertToCurrency;
            }
            set
            {
                convertToCurrency = value;
                OnPropertyChanged("ConvertToCurrency");
            }
        }

        public string ValueToConvert
        {
            get
            {
                return valueToConvert;
            }
            set
            {
                valueToConvert = value;
                OnPropertyChanged("ValueToConvert");
            }
        }

        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        // main method in class for converting currencies
        private double Convert()
        {
            double res = -1, first, second;
            try
            {
                first = GetCoinPrice(BaseCurrency);
                second = GetCoinPrice(ConvertToCurrency);
                if(first < 0)
                {
                    BaseCurrency = "Not Found";
                    
                    if (second < 0)
                    {
                        ConvertToCurrency = "Not found";
                    }
                    return -1;

                }
                if(second < 0)
                {
                    ConvertToCurrency = "Not found";
                    return -1;
                }
                res = Double.Parse(ValueToConvert) * (first / second);
            }
            catch(Exception e)
            {
                ValueToConvert = "Not a number";
            }
            return res;
        }


        public ICommand bConvertTo_Click
        {
            get
            {
                return new RelayCommand(() =>  Result = Convert().ToString("F10") );
            }

        }

        // getting prices
        public double GetCoinPrice(string calledValue)
        {
            Assets asset;


            string ID = NameOrID(calledValue);

            if (ID == "")
            {
                asset = null;
                return -1;
            }

            asset = GetInfoUsingApi.GetOneAsset(ID);

            return asset.asset.price;


        }


        // search for pairs "Namr-ID" or validating ID itself
        private string NameOrID(string calledValue)
        {
            foreach (Coin element in namesIDs.assets)
            {
                if (element.asset_id.ToUpper() == calledValue.ToUpper())
                {
                    return calledValue;
                }
                if (element.name.ToUpper() == calledValue.ToUpper())
                {
                    return element.asset_id;
                }


            }
            return "";
        }

    public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
