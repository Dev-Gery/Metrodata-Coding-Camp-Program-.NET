using api.Model;
using API.Model;
using API.Model.ViewModel;
using API.Repository.ViewModel;
using BelajarCORS.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BelajarCORS.Repositories.Data
{
    public class AccountRepository : GeneralRepository<Account, string>
    {
        public AccountRepository(Address address) : base(address, "Accounts/") { }
        public async Task<object> GetMasterData()
        {
            object result;
            using (var response = await httpClient.GetAsync(request + "getmasterdata"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject(apiResponse);
            }
            return result;
        }
        public async Task<object> GetMasterData(string NIK)
        {
            object result;

            using (var response = await httpClient.GetAsync(request + $"getmasterdata/{NIK}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject(apiResponse);
            }
            return result;
        }
        public object Register(RegisterVM registerVM)
        {
            object responseJSON;
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "register", content).Result)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                responseJSON = JsonConvert.DeserializeObject(responseString);
            }
            return responseJSON;
        }

    }
}