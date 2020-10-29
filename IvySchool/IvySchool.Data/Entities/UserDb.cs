using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IvySchool.Data.Entities
{
     public class UserDb
    {
        public int Id  { get; set; }

        [Required]
        public string Name { get; set; }
        [Required, MaxLength(200), EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted  { get; set; }
        public DateTime CreateAt { get; set; }

    }
}
