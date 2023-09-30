using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.DTOs
{
    public class ProductDTO : BaseDTO
    {
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        [Required(ErrorMessage = "This Name is Required")]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(150)]
        [DisplayName("Description")]
        [Required(ErrorMessage = "This Description is Required")]
        public string Description { get; set; }

        [MinLength(0)]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "This Price is Required")]
        public decimal Price { get; set; }

        [MinLength(0)]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        [Required(ErrorMessage = "This Stock is Required")]
        public int Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Image")]
        public string? Image { get; set; }

        public int CategoryId { get; set; }
        //[DisplayName("Categories")]
        //public Category Category { get; set; }
    }
}