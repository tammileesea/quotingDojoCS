using System.ComponentModel.DataAnnotations;

namespace quotingDojo.Models {
    public class Quote{
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [Display(Name = "Name")]
        public string name {get;set;}

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [Display(Name = "Your Quote")]
        public string content {get; set;}
    }
}