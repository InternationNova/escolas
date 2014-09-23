using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scholas.Models
{
    public class CustomerList : List<Customer>
    {
        public string ImageUrl { get; set; }
    }
}
