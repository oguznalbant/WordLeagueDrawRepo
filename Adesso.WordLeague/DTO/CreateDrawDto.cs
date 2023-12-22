using Adesso.WordLeague.Validators;
using System.ComponentModel.DataAnnotations;

namespace Adesso.WordLeague.DTO
{
    public class CreateDrawDto
    {
        [Required(ErrorMessage = "User First Name is required")]
        [MinLength(2, ErrorMessage = "User First Name can not be less than two characters")]
        [MaxLength(50, ErrorMessage = "User First Name too long")]
        public string UserFirstName { get; set; }

        [Required(ErrorMessage = "User Last Name is required")]
        [MinLength(2, ErrorMessage = "User Last Name can not be less than two characters")]
        [MaxLength(50, ErrorMessage = "User Last Name too long")]
        public string UserLastName { get; set; }

        [MultipleValueCheckValidation(new int[] { 4, 8})]
        public int GroupCount { get; set; }
    }
}
