using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testMiddelware.classes
{
    public class indentity
    {
        [Required (ErrorMessage ="name is required")]
        public string AdminUserName { get; set; }
        [Required ( ErrorMessage ="password is required")]
        public int AdminPassword { get; set; }

        [Required (ErrorMessage = " email is required")]
        [EmailAddress(ErrorMessage ="ایمیل اشتباه")]
        public string AdminEmail { get; set; }
    }
}
