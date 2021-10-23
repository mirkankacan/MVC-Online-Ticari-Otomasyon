using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }
        [Column(TypeName = "Varchar")]
        public string Alici { get; set; }
        [Column(TypeName = "Varchar")]
        public string Gonderici { get; set; }
        [Column(TypeName = "Varchar")]
        public string Konu { get; set; }
        [Column(TypeName = "Varchar")]
        public string Icerik { get; set; }
        [Column(TypeName = "SmallDateTime")]
        public DateTime Tarih { get; set; }
    }
}