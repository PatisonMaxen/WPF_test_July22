using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace WPF_test_July22
{
    // Class for DataContext and logic for Search page
    class SearchFields : INotifyPropertyChanged
    {
        private Page searchSubpage;
        private MarketsPage marketsPage;
        private QuotePage quotePage;
        private string buttonText;
        public Markets markets;

        public Assets asset;

        private Assets namesIDs;
        private MarketsQuotes marketsQuotes;

        public ObservableCollection<InternalExchangesType> sixMarkets { get; set; } // using ObservableCollections for change events
        public ObservableCollection<Coin> searchFields { get; set; }

        public SearchFields()
        {
            namesIDs = new Assets();
            sixMarkets = new ObservableCollection<InternalExchangesType>();
            searchFields = new ObservableCollection<Coin>();
            marketsPage = new MarketsPage();
            quotePage = new QuotePage();
            marketsQuotes = new MarketsQuotes();

            marketsQuotes.SetFields(sixMarkets, searchFields);

            SearchSubpage = marketsPage;

            marketsPage.DataContext = marketsQuotes;
            quotePage.DataContext = marketsQuotes;
            searchFields.Add(new Coin());
            ButtonText = "Markets";
            namesIDs = GetInfoUsingApi.GetNamesIDs();
        }

        public string ButtonText
        {
            get
            {
                return buttonText;
            }

            set
            {
                buttonText = value;
                OnPropertyChanged("ButtonText");
            }
        }
        public Page SearchSubpage
        {
            get => searchSubpage;

            set
            {
                searchSubpage = value;
                OnPropertyChanged("SearchSubpage");
            }
        }

        // getting results by call for Search page and subpages
        public void GetSearchResult(string calledValue)
        {

            string ID = NameOrID(calledValue);

            if(ID == " ")
            {
                asset = null;
                return;
            }

            asset = GetInfoUsingApi.GetOneAsset(ID);
            markets = GetInfoUsingApi.GetMarkets(ID);
            
            searchFields.Clear();
            searchFields.Add(asset.asset);

            SaveMarkets();

            marketsQuotes.SetFields(sixMarkets, searchFields);

        }

        // search for pairs "Namr-ID" or validating ID itself
        private string NameOrID(string calledValue)
        {
            foreach(Coin element in namesIDs.assets)
            {
                if(element.asset_id.ToUpper() == calledValue)
                {
                    return calledValue;
                }
                if(element.name.ToUpper() == calledValue)
                {
                    return element.asset_id;
                }

                
            }
            return " ";
        }

        
        private void SaveMarkets()
        {
            sixMarkets.Clear();
            for (int i = 0; i < 6; i++)
            {
                sixMarkets.Add(markets.markets[i]);
            }
        }

        public ICommand bMarketQuote_Click
        {
            get
            {
                return new RelayCommand(() => {
                    if (ButtonText == "Quote")
                    {
                        ButtonText = "Markets";
                        SearchSubpage = marketsPage;
                    }
                    else
                    {
                        ButtonText = "Quote";
                        SearchSubpage = quotePage;
                    }
                });
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
