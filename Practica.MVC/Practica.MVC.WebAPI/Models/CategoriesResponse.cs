using System.ComponentModel.DataAnnotations;

namespace Practica.MVC.WebAPI.Models
{
    public class CategoriesResponse
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15), MinLength(1)]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}