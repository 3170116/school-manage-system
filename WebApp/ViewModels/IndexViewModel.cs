using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class IndexViewModel
    {

        public Teacher Teacher { get; set; }

        public string AccountExists { get; set; }

        public string SchoolExists { get; set; }
    }
}
