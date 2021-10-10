using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class ToDo
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(50)]
        public string Yapılacak { get; set; }
        [Column(TypeName = "bit")]
 
        public bool Durum { get; set; }
    }
}