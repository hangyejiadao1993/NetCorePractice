using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace User.API.Models
{
    [Table("Users")]
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }
    }
}
