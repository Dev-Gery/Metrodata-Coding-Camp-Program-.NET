using API.Model;
using API.Model.ViewModel;
using API.Repository.ViewModel;
using System.Collections.Generic;
using static API.Repository.Data.AccountRepository;
using static API.Repository.Interface.EmployeeRepository;

namespace API.Repository.Interface
{
    public interface IAccountRepository
    {
        public DataCheckConstants Insert(Account account);
        public DataCheckConstants Register(RegisterVM registerVM);
        MasterEyeDataVM GetMasterEyeData(string NIK);
        IEnumerable<MasterEyeDataVM> GetMasterEyeData();
        public LoginCheckConstants Login(LoginVM loginVM);
        public void GenerateOTP(Account account);
        public DataCheckConstants ResetPassword(string recipientEmail);
        public DataCheckConstants ChangePassword(ChangePasswordVM changePasswordVM);

    }
}
