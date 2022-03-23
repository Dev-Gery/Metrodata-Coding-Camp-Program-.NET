using api.Model;
using System.Collections.Generic;

namespace API.Repository.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        Employee GetNIK(string NIK);
        Employee GetFirstName(string FirstName);
        int Insert(Employee employee);
        int Update(Employee employee);
        int Delete(string NIK);
    }
}
