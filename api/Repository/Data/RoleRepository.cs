using api.Context;
using API.Model;

namespace API.Repository.Data
{
    public class RoleRepository : GeneralRepository<MyContext, Role, int>
    {
        private readonly MyContext myContext;
        public RoleRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}