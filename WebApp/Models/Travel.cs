using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models {
    public class Travel {
        [HiddenInput] public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać datę rozpoczęcia!")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Proszę podać datę zakończenia!")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Proszę podać miejsce początkowe!")]
        public string StartLocation { get; set; }

        [Required(ErrorMessage = "Proszę podać miejsce końcowe!")]
        public string EndLocation { get; set; }

        [Required(ErrorMessage = "Proszę podać uczestników!")]
        public string Participants { get; set; }

        [Required(ErrorMessage = "Proszę podać przewodnika!")]
        public string Guide { get; set; }
    }
}