using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniManagement_MVC.Models
{
    public class Module
    {
        public int Id { get; set; }

        // name .
        [Required]
        public string Name { get; set; }

        //Module credits.
        public int Credits { get; set; }
    }
}
