using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Model
{
    public class SampleModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string note { get; set; }
    }
}
