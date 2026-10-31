using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_82_EF02.Models
{
    internal class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxAtendees { get; set; }

        public int OrganizerID { get; set; }
        public Organizer organizer { get; set; } = null!;

        
    
    }
}
