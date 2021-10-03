using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int Satisid{ get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public DateTime Tarih{ get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public int Adet { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public decimal Fiyat { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public decimal ToplamTutar { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public int Urunid { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public int Cariid { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public int Personelid { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}