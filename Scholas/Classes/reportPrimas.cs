using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scholas.Models;

namespace Scholas.Classes
{
    public class reportPrimas
    {
        public int id { get; set; }
        public int escolasId { get; set; }
        public List<escolas> escolas { get; set; }

    }
}