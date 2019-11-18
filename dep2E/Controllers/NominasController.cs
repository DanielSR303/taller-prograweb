using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dep2E.Models;

namespace dep2E.Controllers
{
    public class NominasController : Controller
    {
        private dep2EEntities db = new dep2EEntities();

        // GET: Nominas
        public ActionResult Index()
        {
            var nominas = db.Nominas.Include(n => n.Empleado).Where(n => n.Empleado.Estado == true);
            return View(nominas.ToList());
        }

        // GET: Nominas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // GET: Nominas/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleados, "idEmpleado", "nombre_Empleado");
            return View();
        }

        // POST: Nominas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idNomina,idEmpleado,sueldo_por_dia,dias_trabajados,sueldo_quincenal,fecha")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Nominas.Add(nomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleados, "idEmpleado", "nombre_Empleado", nomina.idEmpleado);
            return View(nomina);
        }

        // GET: Nominas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleados, "idEmpleado", "nombre_Empleado", nomina.idEmpleado);
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idNomina,idEmpleado,sueldo_por_dia,dias_trabajados,sueldo_quincenal,fecha")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleados, "idEmpleado", "nombre_Empleado", nomina.idEmpleado);
            return View(nomina);
        }

        // GET: Nominas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nomina nomina = db.Nominas.Find(id);
            db.Nominas.Remove(nomina);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BuscarNominaPorFecha(String Fecha)
        {
            ViewBag.Fecha = new SelectList(db.Nominas, "Fecha", "Fecha");

            var busqueda = from s in db.Nominas select s;

            if (!String.IsNullOrEmpty(Fecha))
            {
                busqueda = busqueda.Where(s => s.fecha == Fecha);
            }
            return View(busqueda.ToList());
        }

        public ActionResult NominaPorEmpleado(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nomina nomina = db.Nominas.Find(id);
            if (nomina == null)
            {
                return HttpNotFound();
            }
            return View(nomina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

