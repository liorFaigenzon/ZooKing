using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZooKing.Models
{
    public class Area
    {
        public int ID { get; set; }

        [DisplayName("שם:")]
        [Required]
        public int Name { get; set; }

        [DisplayName("גודל:")]
        [Required]
        public int Size { get; set; }


        public virtual ICollection<Animal> Animals{ get; set; }

        public int ZooID{ get; set; }
        public virtual Zoo Zoo { get; set; }
    }
}