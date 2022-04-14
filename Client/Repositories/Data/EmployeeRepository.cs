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
using System.Text;
using System.Threading.Tasks;

namespace BelajarCORS.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string>
    {   
        public EmployeeRepository(Address address) : base(address, "Employees/")
        {
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }

        public object PutUp(Employee employee)
        {
            object responseJSON;
            StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request, content).Result)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                responseJSON = JsonConvert.DeserializeObject(responseString);
            }
            return responseJSON;
        }
    }
}