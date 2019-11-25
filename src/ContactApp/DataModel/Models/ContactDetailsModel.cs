using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel.Models
{
    public class ContactDetailsModel
    {
        public int Id { get; set; }
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
        public string PhoneNumber { get; set; }
        [Required]
        public Status Status { get; set; }
    }
    public enum Status
    {
        Active,
        Inactive
    }
}
