using api.Model;
using API.Model;
using API.Model.ViewModel;
using API.Repository.ViewModel;
using BelajarCORS.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BelajarCORS.Repositories.Data
{
    public class UniversityRepository : GeneralRepository<University, int>
    {
        public UniversityRepository(Address address) : base(address, "Universities/")
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }

        //public async Task<List<RegisterVM>> GetAllProfile()
        //{
        //    /// isi codingan kalian disini
            
        //}
    }
}