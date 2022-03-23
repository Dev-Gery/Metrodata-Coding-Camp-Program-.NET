using api.Context;
using API.Model;

namespace API.Repository.Data
{
    public class ProfilingRepository : GeneralRepository<MyContext, Profiling, string>
    {
        private readonly MyContext myContext;
        public ProfilingRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
