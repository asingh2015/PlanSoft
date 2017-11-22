//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcAdminTemplate.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Account
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a Username")]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "Username must be 6-16 characters")]
        public string Username { get; set; }

        public int OrgID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a First Name")]
        [StringLength(16, MinimumLength = 1, ErrorMessage = "First Name must be 1-16 characters")]
        public string First { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a Last Name")]
        [StringLength(16, MinimumLength = 1, ErrorMessage = "Last Name must be 1-16 characters")]
        public string Last { get; set; }

        
        public string Role { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must enter a Password")]
        [StringLength(256, MinimumLength = 6, ErrorMessage = "Password must be 6-16 characters")]
        public string Password { get; set; }

        public System.DateTime CreatedOn { get; set; }
        public string PasswordSalt { get; set; }
    
        public virtual Organization Organization { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}