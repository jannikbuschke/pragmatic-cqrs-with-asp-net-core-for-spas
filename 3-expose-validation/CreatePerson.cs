using System;
using System.ComponentModel.DataAnnotations;

namespace Sample
{
    /// Create Person command DTO ///
    public class CreatePerson
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
