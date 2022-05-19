using API.Model.ViewModel;

namespace Client.Models
{
    public class LoginResults
    {
        public int status { get; set; }
        public string jwt { get; set; }
        public string message { get; set; }
    }
}
