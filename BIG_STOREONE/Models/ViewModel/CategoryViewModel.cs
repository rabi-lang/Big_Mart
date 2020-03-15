using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BIG_STOREONE.Models.ViewModel
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}