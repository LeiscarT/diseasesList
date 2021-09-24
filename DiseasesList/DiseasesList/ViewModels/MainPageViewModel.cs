using DiseasesList.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DiseasesList.ViewModels
{
    class MainPageViewModel
    {
        public ICommand NavigateCommand { get; }

        public MainPageViewModel()
        {
            NavigateCommand = new Command(OnSuggest);
        }

        private  async void OnSuggest()
        {
           if(Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new SuggestPage());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "There´s no connection to internet","Ok");
            }
        }
    }
}
