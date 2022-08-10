using Onion.Repository.Users;
using System.ComponentModel.DataAnnotations;

namespace Onion.Infrastructure
{
    public class UserDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = UsersConstants.FirstNameValidationError)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = UsersConstants.FirstNameValidationError)]
        public string LastName { get; set; }

        [Required(ErrorMessage = UsersConstants.FirstNameValidationError)]
        public string MiddleName { get; set; }
    }
}
