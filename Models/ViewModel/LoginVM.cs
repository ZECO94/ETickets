using System.ComponentModel.DataAnnotations;

namespace ETickets.Models.ViewModel
{
    public class LoginVM
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemmemberMe { get; set; }
    }
}
