using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dating.Entities
{
    public class DateDetails
    {
        public DateDetails()
        {
            DateId = Guid.NewGuid();
        }
        [Key]
        public Guid DateId { get; set; }

        [Required]
        public String RequestSenderName { get; set; }

        [Required]
        public String RequestReceiverName { get; set; }

        public String DateOfRequest { get; set; }

        [Required]
        public Status RequestStatus { get; set; }

        [Required]
        public String RequestSenderEmail { get; set; }

        [Required]
        public String RequestReceiverEmail { get; set; }
        [Required]
        public long Mobile { get; set; }

        [Required]
        public String RequestMessage { get; set; }
    }
}