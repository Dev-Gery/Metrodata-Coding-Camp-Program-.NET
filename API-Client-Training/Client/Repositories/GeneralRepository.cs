using BelajarCORS.Base;
using BelajarCORS.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BelajarCORS.Repositories
{
    public class GeneralRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class
    {
        internal readonly Address address;
        internal readonly string request;
        internal readonly IHttpContextAccessor _contextAccessor;
        internal readonly HttpClient httpClient;

        public GeneralRepository(Address address, string request)
        {
            this.address = address;
            this.request = request;
            this._contextAccessor = new HttpContextAccessor();
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link),  
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _contextAccessor.HttpContext.Session.GetString("JWToken"));
        }
        public object Delete(TId id)
        {
            object results;
            using (var response = httpClient.DeleteAsync(request + id).Result)
            {
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                results = JsonConvert.DeserializeObject(apiResponse);
            }
            return results;
        }
        public async Task<object> Get()
        {
            object results;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject(apiResponse);
            }
            return results;
        }
        public async Task<object> Get(TId id)
        {
            object results;
            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                results = JsonConvert.DeserializeObject(apiResponse);
            }
            return results;
        }
        public HttpStatusCode Put(TId id, TEntity entity)
        {
            throw new NotImplementedException();
            //    StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            //    var result = httpClient.PutAsync(request + id, content).Result;
            //    return result.StatusCode;
        }
        public HttpStatusCode Put(TEntity entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync(request, content).Result;
            return result.StatusCode;
        }

        public HttpStatusCode Post(TEntity entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(request, content).Result;
            return result.StatusCode;
        }

       
    }
}