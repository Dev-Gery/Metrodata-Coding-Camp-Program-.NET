using api.Context;
using api.Model;
using API.Model;
using API.Model.ViewModel;
using System.Collections.Generic;

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
