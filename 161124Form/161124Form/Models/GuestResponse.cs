using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _161124Form.Models
{
    public class GuestResponse : Controller
    {
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ange ditt mobilnummer")]
        public string Phone { get; set; }
    }
}