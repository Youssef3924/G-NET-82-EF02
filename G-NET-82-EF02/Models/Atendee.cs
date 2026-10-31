using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_82_EF02.Models
{
    [Table("AtendeeTable")]
    internal class Atendee
    {
        [Key]
        public int AtendeeID {  get; set; }
        [Column(TypeName ="varchar")]
        [MaxLength(150)]
        [Required]

        public string FullName { get; set; } = null!;
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        [Required]

        public string Email { get; set; } = null!;
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        [Required]


        public string street { get; set; } = null!;
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]


        public string city { get; set; } = null!;
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]


        public string Country { get; set; } = null!;
        [Column(name: "ZipCode", TypeName = "varchar")]
        [MaxLength(20)]
        [Required]
        public string PostalCode { get; set; } = null!;
        [NotMapped]
        public Adress FullAdress { get; set; }

        public Badge? badge { get; set; }


    }
}
