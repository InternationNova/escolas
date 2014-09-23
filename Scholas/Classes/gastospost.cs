using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scholas.Models;

namespace Scholas.Classes
{
    public class gastospost
    {
        public gastos gastos { get; set; }
        public List<fornecedores> fornecedores { get; set; }
        public List<tipo_documentos> tipodocumentos { get; set; }
    }
}