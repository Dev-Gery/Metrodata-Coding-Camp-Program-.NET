using api.Context;
using API.Model;

namespace API.Repository.Data
{
    public class AuthorityRepository : GeneralRepository<MyContext, Authority, (string, int)>
    {
        private readonly MyContext myContext;
        public AuthorityRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
