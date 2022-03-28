using api.Model;
using API.Model.ViewModel;
using System.Collections.Generic;
using static API.Repository.Interface.EmployeeRepository;

namespace API.Repository.Interface
{
    public interface IEmployeeRepository
    {  
        DataCheckConstants Insert(Employee employee);
    }
}
