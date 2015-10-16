using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZooKing.Models
{
    public class AnimalAreaViewModel
    {
        public string AreaName { get; set; }
        public string AnimalName { get; set; }

        public int AreaSize { get; set; }
        public int AnimalAge { get; set; }
        public int AnimalId { get; set; }
    }
}