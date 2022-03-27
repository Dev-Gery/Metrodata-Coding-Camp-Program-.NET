using api.Model;
using System.Collections.Generic;

namespace API.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Employee GetFirstName(string FirstName);
    }
}
