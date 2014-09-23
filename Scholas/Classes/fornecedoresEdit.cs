﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scholas.Models;

namespace Scholas.Classes
{
    public class fornecedoresEdit
    {
        public int id { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }
        public string cnpj { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get ; set ;}
        public string cep { get ; set ;}
        public string  telefone { get ; set ;}
        public string  email { get ; set ;}
        public List<estados> estados { get; set; }
    }
}