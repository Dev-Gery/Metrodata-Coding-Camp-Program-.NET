using api.Context;
using API.Model;
using API.Repository;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        public AccountRepository(MyContext myContext): base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
