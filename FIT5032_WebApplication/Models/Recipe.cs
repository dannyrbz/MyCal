namespace FIT5032_WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Path { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Calorie cannot be empty")]
        [Range(1,9999, ErrorMessage = "Calorie must be between 1 - 9999")]
        public int Cal { get; set; }

        public DateTime? DateCreated { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Ingredients cannot be empty")]
        [MaxLength(250, ErrorMessage = "Ingredients cannot be more than 250 characters")]
        public string Ingredients { get; set; }

        [Required(ErrorMessage = "Carbs cannot be empty")]
        [Range(1, 9999, ErrorMessage = "Carbs must be between 1 - 9999")]
        public int Carbs { get; set; }

        [Required(ErrorMessage = "Protein cannot be empty")]
        [Range(1, 9999, ErrorMessage = "Protein must be between 1 - 9999")]
        public int Protein { get; set; }

        [Required(ErrorMessage = "Fat cannot be empty")]
        [Range(1, 9999, ErrorMessage = "Fat must be between 1 - 9999")]
        public int Fat { get; set; }

        [Required(ErrorMessage = "Preperation time cannot be empty")]
        [Range(1, 9999, ErrorMessage = "Preperation time must be between 1 - 9999")]
        public int PrepTime { get; set; }

        [Required(ErrorMessage = "Servings cannot be empty")]
        [Range(1, 100, ErrorMessage = "Servings must be between 1 - 100")]
        public int Servings { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Instructions cannot be empty")]
        [MaxLength(250, ErrorMessage = "Instructions cannot be more than 250 characters")]
        public string Instructions { get; set; }

        public string UserId { get; set; }

        public string MealType { get; set; }

        public string Status { get; set; }

    }
}
