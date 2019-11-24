using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactApp.Models
{
    public class ContactDetails
    {
        public string Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        [Phone]
        [Required]
        public string PhoneNumber{ get; set; }
        [Required]
        public Status Status { get; set; }
    }
    public enum Status{
        Active,
        Inactive
    }
}