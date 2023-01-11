using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using test.Models;




namespace test.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(20)]
        [Phone]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
    }
}
