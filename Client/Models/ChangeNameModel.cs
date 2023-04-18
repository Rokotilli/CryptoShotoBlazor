using System.ComponentModel.DataAnnotations;

namespace Client.Models
{
    public class ChangeNameModel
    {
        [Required(ErrorMessage = "You must enter username")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Max length 15 characters, minimum 3 characters")]
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
