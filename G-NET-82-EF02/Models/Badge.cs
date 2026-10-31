using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_82_EF02.Models
{
    internal class Badge
    {
        public int Id { get; set; }
        public DateTime IsuuedTime { get; set; }
        public string Tier { get; set; } = null!;

        public int AtendeeID { get; set; }
        public Atendee Atendee { get; set; }=null!;
           
    }
}
