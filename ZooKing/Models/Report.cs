﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooKing.Models
{
    public class Report 
    {
        public int ID { get; set; }

        [DisplayName("כותרת:")]
        [Required]
        public string Title { get; set; }

        [DisplayName("החדשות:")]
        [Required]
        public string ShortInfo { get; set; }

        [DisplayName("חדשות לתאריך:")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime UpdateForDate { get; set; }
    }
}