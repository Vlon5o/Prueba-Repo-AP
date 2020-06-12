using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_MVC_AP.Models
{
    public class ClsEjercicio2
    {
        public string numerosactualesizq { get; set; }
        public IEnumerable<SelectListItem> numerosizq { get; set; }
        public IEnumerable<int> numseleccionadosizq { get; set; }

        public string numerosactualesder { get; set; }
        public IEnumerable<SelectListItem> numerosder { get; set; }
        public IEnumerable<int> numseleccionadosder { get; set; }
    }
}