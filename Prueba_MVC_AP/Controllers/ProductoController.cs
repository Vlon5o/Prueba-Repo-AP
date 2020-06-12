using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_MVC_AP.Models;

namespace Prueba_MVC_AP.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            var model = new ClsProducto
            {
                SelectedProIds = new[] { 2 },
                ProList = GetAllProductos()
            };

            return View(model);
        }

        public ActionResult Agregar(ClsProducto model)
        {

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ClsProducto model)
        {
            model.ProList = GetAllProductos();
            if (model.SelectedProIds != null)
            {
                List<SelectListItem> selectedItems = model.ProList.Where(p => model.SelectedProIds.Contains(int.Parse(p.Value))).ToList();

                foreach (var Producto in selectedItems)
                {

                    Producto.Selected = true;
                    //selectedItems.Remove();

                    ViewBag.Message += Producto.Text + " | ";
                }

            }
            return View(model);
        }


        public List<SelectListItem> GetAllProductos()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Azucar", Value = "1" });
            items.Add(new SelectListItem { Text = "Arroz", Value = "2" });
            items.Add(new SelectListItem { Text = "Tomate", Value = "3" });
            items.Add(new SelectListItem { Text = "Agua", Value = "4" });
            return items;
        }

      
    }
}