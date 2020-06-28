using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class Certificate
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? ClassId { get; set; }
        public float FinalDegree { get; set; }
        public DateTime? Date { get; set; }

        public virtual Student Student { get; set; }
    }
}
