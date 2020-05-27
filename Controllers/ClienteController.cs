using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Interview.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            IEnumerable<DtoProducto> lprod = null;
            HttpClient ht = new HttpClient();
            ht.BaseAddress = new Uri("https://localhost:44377/api/ServicioRestProducto");
            var consume = ht.GetAsync("ServicioRestProducto");
            consume.Wait();
            var resconsume = consume.Result;
            if (resconsume.IsSuccessStatusCode)
            {
                var mostrardatos = resconsume.Content.ReadAsAsync<IList<DtoProducto>>();
                mostrardatos.Wait();
                lprod = mostrardatos.Result;
            }
            return View(lprod);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DtoProducto dtoproc)
        {
            if (ModelState.IsValid)
            {
                HttpClient ht = new HttpClient();
                ht.BaseAddress = new Uri("https://localhost:44377/api/ServicioRestProducto");
                var registro = ht.PostAsJsonAsync<DtoProducto>("ServicioRestProducto", dtoproc);
                registro.Wait();
                var registroguardado = registro.Result;
                if (registroguardado.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }

            }
            return View("Create");
        }
        public ActionResult Details(int id)
        {
            DtoProducto dtprod = null;
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://localhost:44377/api/");
            var con = cliente.GetAsync("ServicioRestProducto?id=" + id.ToString());
            con.Wait();
            var detalle = con.Result;
            if (detalle.IsSuccessStatusCode)
            {
                var mostrardetalle = detalle.Content.ReadAsAsync<DtoProducto>();
                mostrardetalle.Wait();
                dtprod = mostrardetalle.Result;
            }
            return View(dtprod);
        }
        public ActionResult Edit(int id)
        {
            DtoProducto dtprod = null;
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri("https://localhost:44377/api/");
            var con = cliente.GetAsync("ServicioRestProducto?id=" + id.ToString());
            con.Wait();
            var detalle = con.Result;
            if (detalle.IsSuccessStatusCode)
            {
                var mostrardetalle = detalle.Content.ReadAsAsync<DtoProducto>();
                mostrardetalle.Wait();
                dtprod = mostrardetalle.Result;
            }
            return View(dtprod);

        }
        [HttpPost]
        public ActionResult Edit(DtoProducto produc)
        {
            HttpClient ht = new HttpClient();
            ht.BaseAddress = new Uri("https://localhost:44377/api/ServicioRestProducto");
            var registro = ht.PutAsJsonAsync<DtoProducto>("ServicioRestProducto", produc);
            registro.Wait();
            var registroguardado = registro.Result;
            if (registroguardado.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.mensaje = "El registro no ha podido ser modificado";
            }

            return View(produc);
        }
        public ActionResult Delete(int id)
        {
            HttpClient ht = new HttpClient();
            ht.BaseAddress = new Uri("https://localhost:44377/api/ServicioRestProducto");
            var delrecord = ht.DeleteAsync("ServicioRestProducto/" + id.ToString());
            delrecord.Wait();
            var deldata = delrecord.Result;
            if (deldata.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
        }

    }
}