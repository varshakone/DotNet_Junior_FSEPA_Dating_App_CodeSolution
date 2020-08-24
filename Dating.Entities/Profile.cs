using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dating.Entities
{
  public  class Profile
    {
        [Key]
        public Guid ProfileId { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public String Gender { get; set; }

        [Required]
        public String Occupation { get; set; }

        [Required]
        public String AlternateEmail { get; set; }

        [Required]
        public long MobileNumber { get; set; }
    }
}
