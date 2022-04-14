using API.Model.ViewModel;

namespace Client.Models
{
    public class Results
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public MasterEyeDataVM Result { get; set; }
    }
}
