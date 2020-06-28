using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Absence
    {
        public int? Id { get; set; }
        public int? StudentId { get; set; }
        public int? TeachingHourId { get; set; }
        public bool Justified { get; set; }
        public bool IsPunishment { get; set; }
        public DateTime Date { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teachinghour TeachingHour { get; set; }
    }
}
