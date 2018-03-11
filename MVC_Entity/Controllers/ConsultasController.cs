using MVC_Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Entity.Controllers
{
    public class ConsultasController : Controller
    {
        private MVC_EntityContext db = new MVC_EntityContext();
        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult PesquisaCliente() {
            string nome = Request.Form["nome"];
            var clientes = db.Clients.Where(c => c.nome.Contains(nome));
            ViewBag.clientes = clientes.ToList();
            return View("PesquisaCliente");
        }

        public ActionResult ListaEstadias(int? id) {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var estadias = db.Stays.Where(e => e.ClientId == id).Include(e => e.client).Include(e => e.room);
            return View(estadias.ToList());
        }

        public ActionResult PesquisaDinamica() {
            return View();
        }

        public JsonResult PesquisaNome(string nome) {
            var clientes = db.Clients.Where(c => c.nome.Contains(nome)).ToList();
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MelhorCliente() {
            using(var context=new MVC_EntityContext()) {
                string sql = @"Select nome,sum(cost_paid) as valor
                              FROM stays INNER JOIN clients
                                ON stays.clientid=clients.clientid
                                GROUP BY stays.clientid,nome
                                ORDER BY sum(cost_paid) DESC";
                var melhor = context.Database.SqlQuery<Campos>(sql);
                ViewBag.melhor = melhor.ToList()[0];
            }
            return View();
        }

        public class Campos {
            public string nome { get; set; }
            public decimal valor { get; set; }
        }
    }
}