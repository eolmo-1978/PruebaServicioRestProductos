using Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;

namespace Interview.Controllers
{
    public class ServicioRestProductoController : ApiController
    {
        InventarioProductosEntities db = new InventarioProductosEntities();
        [HttpGet]
        public IHttpActionResult getproductos()
        {
            var listproductos = db.Tabla_Productos.ToList();
            return Ok(listproductos);
        }
        [HttpGet]
        public IHttpActionResult getproductbydescription(string descrip)
        {
            var lista = db.Tabla_Productos.Where(l => l.Descripcion.Contains(descrip)).FirstOrDefault();
            return Ok(lista);

        }
        public IHttpActionResult postproducto(Tabla_Productos pr)
        {
            db.Tabla_Productos.Add(pr);
            db.SaveChanges();
            return Ok();
        }
        public IHttpActionResult Getproductoid(int id)
        {
            var dtopro = db.Tabla_Productos.Where(l => l.IdProducto == id).FirstOrDefault();
            if (dtopro == null)
            {
                return NotFound();
            }
            return Ok(dtopro);
        }
        
        public IHttpActionResult Putemp(DtoProducto producto)
        {
            var intoproducto = db.Tabla_Productos.Where(l => l.IdProducto == producto.IdProducto).FirstOrDefault();
            if (intoproducto != null)
            {
                intoproducto.IdProducto = producto.IdProducto;
                intoproducto.Nombre = producto.Nombre;
                intoproducto.Descripcion = producto.Descripcion;
                intoproducto.Precio = producto.Precio;
                intoproducto.Categoria = producto.Categoria;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult Deleteproducto(int id)
        {
            var productoborrado = db.Tabla_Productos.Where(l => l.IdProducto == id).FirstOrDefault();
            db.Entry(productoborrado).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();

        }
    } 
}
