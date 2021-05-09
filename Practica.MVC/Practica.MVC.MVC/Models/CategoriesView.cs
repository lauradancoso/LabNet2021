using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica.MVC.MVC.Models
{
    public class CategoriesView
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(15),MinLength(1)]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}