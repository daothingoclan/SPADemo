using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPADemo.Domain
{
    public class Animal
    {
        [Key]
        [Column(Order=1)]
        public int ID { get; set; }

        [Required]
        [Column(Order =2)]
        [MaxLength(100)]
        [ConcurrencyCheck]
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string Color { get; set; }

        public string AvatarURL { get; set; }
    }
}
