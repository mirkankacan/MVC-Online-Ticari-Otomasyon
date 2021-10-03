using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Gider
    {
        [Key]
        public int Giderid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz!")]
        public string Aciklama { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}