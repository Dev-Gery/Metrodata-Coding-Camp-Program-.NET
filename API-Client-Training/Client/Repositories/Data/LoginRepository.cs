using api.Model;
using API.Model;
using API.Model.ViewModel;
using API.Repository.ViewModel;
using BelajarCORS.Base;
using Client.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BelajarCORS.Repositories.Data
{
    public class LoginRepository : GeneralRepository<LoginVM, string>
    {
        public LoginRepository(Address address) : base(address, "Accounts/") { }
        public LoginResults Ate(LoginVM loginVM)
        {
            LoginResults results;
            StringContent content = new StringContent(JsonConvert.SerializeObject(loginVM), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "login", content).Result)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                results = JsonConvert.DeserializeObject<LoginResults>(apiResponse);
            }
            return results;
        }
    }
}