using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_test_July22
{
    // Class for binding as DataContext to Market and Quote subpages
    class MarketsQuotes
    {
        public ObservableCollection<InternalExchangesType> marketFields { get; set; }
        public ObservableCollection<Coin> quoteFields { get; set; }

        public void SetFields(ObservableCollection<InternalExchangesType> market, ObservableCollection<Coin> quote)
        {
            marketFields = market;
            quoteFields = quote;
        }
    }
}
