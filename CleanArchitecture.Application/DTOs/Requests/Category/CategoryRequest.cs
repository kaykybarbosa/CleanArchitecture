using CleanArchitecture.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs.Requests.Category
{
    public class CategoryRequest
    {
        [MinLength(3)]
        [MaxLength(100)]
        [Required(ErrorMessage = "This Name is Required")]
        public string Name { get; set; }

        //public IEnumerable<Product> Products { get; set; }
    }
}
