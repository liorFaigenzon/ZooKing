using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZooKing.Models
{
    public class Zoo
    {
        public int ID { get; set; }

        [DisplayName("שם גן החיות:")]
        [Required]
        public string Name{ get; set; }

        [DisplayName("מידע:")]
        [Required]
        public string ShortInfo { get; set; }

        [DisplayName("שנת הקמה")]
        [Required]
        public DateTime YearOfEstablishment { get; set; }

        public virtual ICollection<Area> Areas { get; set; }

        [DisplayName("כתובות")]
        [Required]
        public string Addres { get; set; }
    }
}