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


        public string Name { get; set; }
        public string Porcentage { get; set; }


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
                    Name = suggest[0];
                    Porcentage = suggest[1];
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
