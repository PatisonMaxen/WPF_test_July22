using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
     class AppViewModel : INotifyPropertyChanged
    {
        private Page currentPage;

        private Top10Page top10Page;

        private SearchPage searchPage;

        private string iD;

        private SearchFields sFields;


        public AppViewModel()
        {
            
            top10Page = new Top10Page();

            searchPage = new SearchPage();

            top10Page.DataContext = new AssetsLoader();

            CurrentPage = top10Page;

            ID = "";

            sFields = new SearchFields();

            searchPage.DataContext = sFields;

        }

        public string ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
                OnPropertyChanged("ID"); 
            }
        }

        public Page CurrentPage 
        { 
            get => currentPage;

            set 
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }  
        }

        
        public ICommand bTop10_Click
        {
            get
            {
                return new RelayCommand(() => CurrentPage = top10Page);
            }
       
        }

     

        public ICommand bSearch_Click
        {
            get
            {
                return new RelayCommand(() => { sFields.GetSearchResult(ID); CurrentPage = searchPage;  });
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
