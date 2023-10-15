using ClasesData;
using Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Control.Controllers
{
    public class CategoriasController : Controller
    {
        private RestauranteEntities Categ = new RestauranteEntities();

        // GET: Categorias
        public ActionResult Index()
        {
            // Aquí puedes agregar lógica para mostrar una lista de categorías en la vista.
            var categorias = Categ.Categorias.ToList();
            return View(categorias);
        }

        // POST: Categorias/AgregarCategoria
        [HttpPost]
        public ActionResult AgregarCategoria(Categoriasclasso nuevaCategoria)
        {
            try
            {
                var categoriaExistente = Categ.Categorias.FirstOrDefault(c => c.Nombre == nuevaCategoria.Nombre);

                if (categoriaExistente != null)
                {
                    ModelState.AddModelError("Nombre", "Ya existe una categoría con ese nombre.");
                    return View(nuevaCategoria);
                }

                var nuevaCategoriaEntity = new Categorias
                {
                    Nombre = nuevaCategoria.Nombre
                };

                Categ.Categorias.Add(nuevaCategoriaEntity);
                Categ.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Ocurrió un error al agregar la categoría.");
                return View(nuevaCategoria);
            }
        }
    }
}
