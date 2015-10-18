using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ZooKing.Models
{
    public class AnimalAreaViewModel
    {
        [DisplayName("שם האזור:")]
        public string AreaName { get; set; }
        [DisplayName("שם החיה:")]
        public string AnimalName { get; set; }
        [DisplayName("גודל האזור:")]
                public int AreaSize { get; set; }
        [DisplayName("גיל:")]
        public int AnimalAge { get; set; }
        [DisplayName("קוד חיה:")]
        public int AnimalId { get; set; }
    }
}