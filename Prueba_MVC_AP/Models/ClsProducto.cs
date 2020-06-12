using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_MVC_AP.Models
{
    public class ClsProducto
    {
        public string producto { get; set; }

        public int[] SelectedProIds { get; set; }
        public IEnumerable<SelectListItem> ProList { get; set; }

    }
}