using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniManagement_MVC.Models
{
    public class Service
    {
        //Primary key
        public int Id { get; set; }

        //id
        public int DepartmentId { get; set; }

        //Lecturer id 
        public int LecturerId { get; set; }

        //Module Id
        public int ModuleId { get; set; }


        //Department reference

        [Required]

        public Department Department { get; set; }

        //Module reference 
        [Required]
        public Module Module { get; set; }

        //Lecturer reference
        [Required]
        public Lecturer Lecturer { get; set; }

    }
}
