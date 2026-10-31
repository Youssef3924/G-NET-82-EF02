using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_82_EF02.Models
{
    internal class OrganizerProfile
    {
        public int Id { get; set; }
        public string Biography { get; set; }
        public string WebSite_Url { get; set; }
        public string Logo_Url { get; set; }
        public int OrganizerID { get; set; }
        public Organizer organizer { get; set; } = null!;
    }
}
