using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_WebApplication.Models
{
    public class CalculationModel
    {
        [Required(ErrorMessage = "Age cannot be empty")]
        [Range(0, 100, ErrorMessage = "Age must be between 0 - 100")]
        public double Age { get; set; }

        public string Gender { get; set; }

        [Range(0,300, ErrorMessage = "Height must be between 0 - 300")]
        [Required(ErrorMessage = "Height cannot be empty")]
        public double Height { get; set; }

        [Range(0, 300, ErrorMessage = "Weight must be between 0 - 300")]
        [Required(ErrorMessage = "Weight cannot be empty")]
        public double Weight { get; set; }

        public string Activity { get; set; }

        public double Result { get; set; }

        public double ResultAdd500 { get; set; }
        public double ResultAdd1000 { get; set; }
        public double ResultMinus500 { get; set; }
        public double ResultMinus1000 { get; set; }
    }
}