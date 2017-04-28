using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _20170407_ClinicaVet.Models;

namespace _20170407_ClinicaVet.Controllers
{
    public class DonosController : Controller
    {
        //Cria uma instância que representa a Base de Dados
        private VetsDB db = new VetsDB();

        // GET: Donos
        public ActionResult Index()
        {
            //Retorna a VIEW, com a lista de donos ordenada pelo ID do dono
            return View(db.Donos.ToList().OrderBy(d=>d.DonoID));
        }

        // GET: Donos/Details/5
        public ActionResult Details(int? id)
        {
            //Caso 'id' do dono seja null
            if (id == null)
            {
                //Redireciona o utilizador para a view INDEX
                return RedirectToAction("Index");
            }
            //Procura o dono com o id fornecido pela view
            Donos donos = db.Donos.Find(id);

            //verifica se o dono foi encontrado
            if (donos == null)
            {
                //Redireciona para a view INDEX
                return RedirectToAction("Index");
            }
            //retorna a view INDEX com os dados do dono
            return View(donos);
        }

        // GET: Donos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DonoID,Nome,NIF")] Donos donos)
        {
            if (ModelState.IsValid)
            {
                //se os dados forem válidos, adiciona o dono
                db.Donos.Add(donos);
                //guarda as alterações
                db.SaveChanges();
                //redireciona para a view INDEX
                return RedirectToAction("Index");
            }
            //retorna a view CREATE com o dono
            return View(donos);
        }

        // GET: Donos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //caso o id seja nulo redireciona para a view INDEX
                return RedirectToAction("Index");
            }
            //Procura o dono com o id fornecido pela view
            Donos donos = db.Donos.Find(id);
            if (donos == null)
            {
                //caso o id seja nulo redireciona para a view INDEX
                return RedirectToAction("Index");
            }
            //retorna a view com os dados do dono
            return View(donos);
        }

        // POST: Donos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DonoID,Nome,NIF")] Donos donos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donos);
        }

        // GET: Donos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Donos donos = db.Donos.Find(id);
            if (donos == null)
            {
                return RedirectToAction("Index");
            }
            return View(donos);
        }

        // POST: Donos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donos donos = db.Donos.Find(id);
            db.Donos.Remove(donos);
            db.SaveChanges();
            return RedirectToAction("Index");
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
