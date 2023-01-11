using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using test.Models;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class File
    {
        
        public byte[] FileData { get; set; }

        public Guid Id { get; set; }
    }
}


