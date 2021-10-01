 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int Urunid { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Urunad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Marka { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public short Stok { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public decimal AlisFiyat { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public decimal SatisFiyat { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public bool Durum { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter girebilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string UrunGorsel { get; set; }
        [Required(ErrorMessage = "Seçim yapmalısınız!")]
        public int Kategoriid { get; set; }
        [Required]
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}