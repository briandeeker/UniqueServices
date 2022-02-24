using System.ComponentModel.DataAnnotations;

namespace Template.Models
{
    public class EmailMessageViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(15, ErrorMessage = "First name can't contain more than 15 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(15, ErrorMessage = "Last name can't contain more than 15 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter at least one e-mail address.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone]
        public string Phone { get; set; }

        [StringLength(500, ErrorMessage = "Message can't contain more than 500 characters.")]
        public string Message { get; set; }

        public string RedirectUrl { get; set; }
    }
}
