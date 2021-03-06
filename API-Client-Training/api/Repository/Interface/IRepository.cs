using System.Collections.Generic;
using static API.Repository.Interface.EmployeeRepository;

namespace API.Repository.Interface
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        IEnumerable<Entity> Get();
        Entity Get(Key key);
        Key GetKeyValues(Entity entity);
        int Insert(Entity entity);
        int Update(Entity entity, Key key);
        int Update(Entity entity);
        int Delete(Key key);
        int DeleteAll();
    } 
}
