using System.ComponentModel.DataAnnotations;

namespace my_webapi_demo.Models
{
    public class Book
    {
        [Required]
        public Guid Id {get; set;}

        [Required]
         public string Title {get; set;}

         [Required]
         [Range(0,100)]
         public decimal Price {get; set;}
    }
}