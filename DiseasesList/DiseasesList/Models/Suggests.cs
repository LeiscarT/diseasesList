using System;
using System.Collections.Generic;
using System.Text;

namespace DiseasesList.Models
{
   public class Suggests
    {
        public string Status { get; set; }
        public List<List<string>> SuggestedSpecializations { get; set; }
       
    }
}
