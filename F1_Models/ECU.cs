using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace F1_Models
{
    public class ECU
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Version { get; set; }

        public string Limit { get; set; }
    }
}
