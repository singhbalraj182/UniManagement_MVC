using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniManagement_MVC.Models
{
    public class Department
    {

        //Primary key.
        public int Id { get; set; }

        //Department name.
        [Required]
        public string Name { get; set; }

        //Department email.
        public string Email { get; set; }
    }
}
