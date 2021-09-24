using System;
using System.Collections.Generic;
using System.Text;

namespace DiseasesList.Models
{
   public class SuggestResponse
    {
        public SuggestResponse(string name, string porcentage)
        {
            Name = name;
            Porcentage = porcentage;
        }

        public string Name { get; set; }

        public string Porcentage { get; set; }
    }
}
