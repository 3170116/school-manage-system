using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public partial class School
    {
        public School()
        {
            Classroom = new HashSet<Classroom>();
            Teachersperschool = new HashSet<Teachersperschool>();
        }

        public int Id { get; set; } = 1;

        [Required]
        public string FullName { get; set; }
        [Required]
        public string Area { get; set; }

        public virtual ICollection<Classroom> Classroom { get; set; }
        public virtual ICollection<Teachersperschool> Teachersperschool { get; set; }
    }
}
