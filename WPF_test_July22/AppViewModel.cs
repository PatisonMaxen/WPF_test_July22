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
        // necessary pages
        private Page currentPage;
        private Top10Page top10Page;
        private SearchPage searchPage;
        private ConvertPage convertPage;
        private NotFoundPage notFoundPage;

        private string iD;

        // objects for DataContext
        private SearchFields sFields;
        private Top10Fields t10Fields;
        private Converter converter;


        public AppViewModel()
        {
            
            top10Page = new Top10Page();
            searchPage = new SearchPage();
            notFoundPage = new NotFoundPage();
            convertPage = new ConvertPage();

            sFields = new SearchFields();
            t10Fields = new Top10Fields();
            converter = new Converter();

            searchPage.DataContext = sFields;
            top10Page.DataContext = t10Fields;
            convertPage.DataContext = converter;

            CurrentPage = top10Page; // start application with TOP10 page
            ID = " ";

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
                return new RelayCommand(() => { t10Fields.GetSearchResult(); CurrentPage = top10Page; });
            }
       
        }

     

        public ICommand bSearch_Click
        {
            get
            {
                return new RelayCommand(() => { 
                    sFields.GetSearchResult(ID.ToUpper());
                    if (sFields.asset == null)
                    {
                        CurrentPage = notFoundPage;
                    }
                    else
                    {
                        CurrentPage = searchPage;
                    }
                      
                });
            }

        }

        public ICommand bConvert_Click
        {
            get
            {
                return new RelayCommand(() =>  CurrentPage = convertPage);
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
