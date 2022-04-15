using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BelajarCORS.Repositories.Interface
{
    public interface IRepository<T, X>
        where T : class
    {
        Task<object> Get();
        Task<object> Get(X id);
        HttpStatusCode Post(T entity);
        HttpStatusCode Put(X id, T entity);
        HttpStatusCode Put(T entity);
        HttpStatusCode Delete(X id);
    }
}