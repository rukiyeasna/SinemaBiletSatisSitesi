using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBSSProje.Web.Areas.Admin.Models
{
    public class MovieUpdateViewModel
    {

        public int MovieId { get; set; }
        [Display(Name = "Film Ad")]
        [Required(ErrorMessage = "Film adı alanı boş geçilemez")]
        public string MovieName { get; set; }
        [Display(Name = "Tarih")]
        [Required(ErrorMessage = "Tarih alanı boş geçilemez")]
        public DateTime Date { get; set; }

        [Display(Name = "Yönetmen")]
        [Required(ErrorMessage = "Yönetmen alanı boş geçilemez")]
        public string Director { get; set; }
        [Display(Name = "Oyuncular")]
        [Required(ErrorMessage = "Oyuncular alanı boş geçilemez")]
        public string Cast { get; set; }
        [Display(Name = "Süre")]
        [Required(ErrorMessage = "Süre alanı boş geçilemez")]
        public string Time { get; set; }
        [Display(Name = "Etiket")]
        public string Type { get; set; }
        [Display(Name = "Açıklama")]
        public string Explanation { get; set; }
        [Display(Name = "Afiş :")]
        public string Picture { get; set; }
        [NotMapped]
        public IFormFile ResimDosyasi { get; set; }
        public string Trailer { get; set; }
        public bool Status { get; set; }
    }
}
