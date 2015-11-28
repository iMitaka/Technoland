using Technoland.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaptopSystem.Web.Models
{
    public class SubmitCommentModel
    {
        [Required]
        [ShouldNotContainEmail]
        public string Comment { get; set; }

        public int SmartphoneId { get; set; }
        public int LaptopId { get; set; }
    }
}