using DiseasesList.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiseasesList.Services
{
    public interface IMedicalApiService
    {
        Task<Suggests> GetSuggests();

    }
}
