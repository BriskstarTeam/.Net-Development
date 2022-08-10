using System.ComponentModel.DataAnnotations;

namespace Onion.Repository.Users.Models
{
    public partial class User
    {
        public long Id { get; set; }

        [Required(ErrorMessage = UsersConstants.FirstNameValidationError)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = UsersConstants.LastNameValidationError)]
        public string LastName { get; set; }

        [Required(ErrorMessage = UsersConstants.MiddleNameValidationError)]
        public string MiddleName { get; set; }
    }
}
