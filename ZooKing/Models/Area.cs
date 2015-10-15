using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ZooKing.Models
{
    public class Area
    {
        public int ID { get; set; }

        [DisplayName("שם:")]
        [Required]
        public string Name { get; set; }

        [DisplayName("גודל:")]
        [Required]
        public int Size { get; set; }

        public string Picture { get; set; }
        [DisplayName("תמונה:")]
        [NotMapped]
        public HttpPostedFileBase PictureFileHandler { get; set; }

        public virtual ICollection<Animal> Animals{ get; set; }

        public int ZooID{ get; set; }
        public virtual Zoo Zoo { get; set; }
    }
}