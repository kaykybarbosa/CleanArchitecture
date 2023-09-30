using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs
{
    public class CategoryDTO : BaseDTO
    {
        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "This Name is Required")]
        public string Name { get; set; }
    }
}