using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scholas.Models;

namespace Scholas.Classes
{
    public class smkAccessory
    {
        public int id { get ; set ;}
        public string codigo_smk { get; set; }
        public int cmp_id { get; set; }
        public int unidade { get; set; }
        public double quantitide { get; set; }
        public int sub_produtos_id { get; set; }
        public string categoria { get; set; }
       
       
    }
}