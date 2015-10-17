using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ZooKing.Models
{
    public class ZooAreaViewModel
    {
        [DisplayName("שם האוזר:")]
        public string AreaName { get; set; }
        [DisplayName("גודל האזור:")]
        public int AreaSize{ get; set; }
        [DisplayName("גן החיות:")]
        public string ZooName { get; set; }
        [DisplayName("פרטי גן החיות:")]
        public string ZooShortInfo { get; set; }
    }
}