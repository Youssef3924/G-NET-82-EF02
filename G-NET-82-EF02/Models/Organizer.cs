using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_82_EF02.Models
{
    [Table("EventOrganizers")]
    internal class Organizer
    {
        [Key]
        public int OrganizerID { get; set; }
      
        [Column(TypeName ="varchar")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = null!;
        [Column(TypeName = "varchar")]
        [MaxLength(150)]
        public string? CompanyName { get; set; } = null!;

        public bool IsVerified { get; set; }
        #region Profile_RelationShip
        [InverseProperty(nameof(OrganizerProfile.organizer))]
        public OrganizerProfile Profile { get; set; } = null!;
        #endregion

        #region OrganizerEvents_RelationShip
        [InverseProperty(nameof(Event.organizer))]
        public ICollection<Event>? Events { get; set; }= new HashSet<Event>();
        #endregion


    }
}
