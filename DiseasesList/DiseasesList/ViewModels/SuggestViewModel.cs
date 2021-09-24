using DiseasesList.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DiseasesList.ViewModels
{
    public class SuggestViewModel : BaseViewModel
    {
        public string Value { get; set; }
        public ICommand GetCommand { get; }
        IMedicalApiService _service;

        public SuggestViewModel(IMedicalApiService service)
        {
            _service = service;
            GetCommand = new Command(OnGet);
        }

        private async void OnGet()
        {
          var suggestsResponse = await _service.GetSuggestsAsync();
          if(suggestsResponse != null)
            {
                Value = string.Join(", ", suggestsResponse.SuggestedSpecializations[0]);

            }
        
        }
    }
}
