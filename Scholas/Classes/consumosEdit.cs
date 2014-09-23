using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scholas.Models;

namespace Scholas.Classes
{
    public class consumosEdit
    {
        public int id { get; set; }
        public double quantidade { get; set; }
        public string unidade { get; set; }
        public int materia_primas_id { get; set; }
        public List<materia_primas> materia_primas { get; set; }
    }
}