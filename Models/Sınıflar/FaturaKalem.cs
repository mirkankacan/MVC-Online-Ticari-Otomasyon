using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter girebilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public int Miktar { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public decimal BirimFiyat { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public decimal Tutar { get; set; }
        public Faturalar Faturalar { get; set; }
    }
}