﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Prueba_MVC_AP.Models;

namespace Prueba_MVC_AP.Controllers
{
    public class PruebaController : Controller
    {
        // GET: Prueba
        [HttpGet]
        public ActionResult Index()
        {        
            List<int> items = new List<int>();

            for (int i = 1; i <= 10; i++)
            {  
                items.Add(i);
            }
            
            ClsPrueba num = GetModel(items, new List<int>());

            return View(num);
        }

        [HttpPost]
        public ActionResult Index(ClsPrueba model)
        {
            List<int> izq = GetNumbers(model.numerosactualesizq);
            List<int> der = GetNumbers(model.numerosactualesder);

            if (model.numseleccionadosizq != null)
            {
                foreach (var i in model.numseleccionadosizq)
                {
                    izq.Remove(i);
                    der.Add(i);
                }
            }

            if (model.numseleccionadosder != null)
            {
                foreach (var i in model.numseleccionadosder)
                {
                    der.Remove(i);
                    izq.Add(i);
                }
            }
            return View(GetModel(izq, der));
        }

        private List<int> GetNumbers(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return new List<int>();
            }
            else
            {
                return numbers.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();
            }
        }

        private ClsPrueba GetModel(IEnumerable<int> izq, IEnumerable<int> der)
        {
            ClsPrueba model = new ClsPrueba();

            if (izq.Any())
            {
                model.numerosactualesizq = izq.Select(n => n.ToString()).Aggregate((x, y) => x + "," + y);
                model.numerosizq = izq.OrderBy(x => x).Select(n => new SelectListItem { Value = n.ToString(), Text = n.ToString() });
            }
            else
            {
                model.numerosizq = new List<SelectListItem>();
            }

            if (der.Any())
            {
                model.numerosactualesder = der.Select(n => n.ToString()).Aggregate((x, y) => x + "," + y);
                model.numerosder = der.OrderBy(x => x).Select(n => new SelectListItem { Value = n.ToString(), Text = n.ToString() });
            }
            else
            {
                model.numerosder = new List<SelectListItem>();
            }
            return model;
        }
    }
}