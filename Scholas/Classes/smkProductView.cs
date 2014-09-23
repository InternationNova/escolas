using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scholas.Models;

namespace Scholas.Classes
{
    public class smkProductView
    {
        
        public List<smkSubProdus> smkSubProdus { get; set; }
        public List<smkAccessory> smkAccessory1 { get; set; }
        public List<smkAccessory> smkAccessory2 { get; set; }
    }
}