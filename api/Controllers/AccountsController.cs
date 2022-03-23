using API.Controllers.Base;
using API.Model;
using API.Repository.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        public AccountsController(AccountRepository accountRepository) : base(accountRepository)
        {

        }
    }
}
