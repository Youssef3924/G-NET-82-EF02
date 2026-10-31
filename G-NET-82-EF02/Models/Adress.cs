using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_82_EF02.Models
{
    internal class Adress
    {

        public string street { get; set; } = null!;
        


        public string city { get; set; } = null!;
       

        public string Country { get; set; } = null!;
       
        public string PostalCode { get; set; } = null!;
    }
}
