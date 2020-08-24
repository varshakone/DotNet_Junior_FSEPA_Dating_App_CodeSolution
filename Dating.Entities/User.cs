using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dating.Entities
{
 public class User
    {

        public User()
        {
            UserId = Guid.NewGuid();
        }
        [Key]
        public Guid UserId { get; set; }

        [Required]
        public String UserName { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public long MobileNumber { get; set; }
    }
}
