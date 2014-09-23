using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scholas.Models;
using System.Data.SqlClient;

namespace Scholas.Classes
{
    public class escolasIndex
    {
        public int id { get; set; }
        public escolas escolas { get; set; }
        public string estados_nome { get; set; }
    }
}