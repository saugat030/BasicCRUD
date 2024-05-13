using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MouseRazor.Model
{
    public class Category
        {
            [Key]
            public int CategoryId { get; set; }
            [Required]
            [DisplayName("Genre Name")]
            [MaxLength(25)]
            public string? Name { get; set; }
            [Required]
            [DisplayName("Display Order")]
            [Range(1, 50, ErrorMessage = "Range milena solti")]
            public int DisplayOrder { get; set; }
            public int MyProperty3 { get; set; }
        }
}

