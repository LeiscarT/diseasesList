using DiseasesList.Models;
using DiseasesList.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiseasesList.ViewModels
{
    public class SuggestViewModel : INotifyPropertyChanged
    {
        // private string _value;
      //  public string Value { get { return _value; } set { _value = value; OnPropertyChanged(nameof(Value)); } }

        public ObservableCollection<SuggestResponse> Value { get; set; }

        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); }}
        private string _porcentage;
        public string Porcentage { get { return _porcentage;} set { _porcentage = value; OnPropertyChanged(nameof(Porcentage)); } }


        public ICommand GetCommand { get; }
        IMedicalApiService _service;

        public event PropertyChangedEventHandler PropertyChanged;

        public SuggestViewModel(IMedicalApiService service)
        {
            Value = new ObservableCollection<SuggestResponse>();
            _service = service;
            OnGet();
          //  GetCommand = new Command(OnGet);
        }

        private async void OnGet()
        {
          var suggestsResponse = await _service.GetSuggestsAsync();
          if(suggestsResponse != null)
            {
                foreach (List<string> suggest in suggestsResponse.SuggestedSpecializations)
                {
                    //  Value = string.Join(", ", suggest[0]);
                    _name = suggest[0];
                    _porcentage = suggest[1];
                    Value.Add(new SuggestResponse(Name, Porcentage));
                    
                }
            }
        
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
