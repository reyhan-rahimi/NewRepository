using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testMiddelware
{
    public class ClassTest
    {
        [Required(ErrorMessage ="name is required")]
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
