using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZooKing.Models
{
    public class Animal
    {
        public int ID { get; set; }
        [DisplayName("שם החיה:")]
        [Required]
        public string Name { get; set; }
        [DisplayName("גיל:")]
        [Required]
        public int Age { get; set; }
        public int Type { get; set; }
        [DisplayName("תמונה:")]
        public string Picture { get; set; }
        [DisplayName("תמונה:")]
        [NotMapped]
        public HttpPostedFileBase PictureFileHandler { get; set; }
        public int AreaID { get; set; }
        public virtual Area Area { get; set; }
    }
}