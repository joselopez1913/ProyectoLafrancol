using Lafrancol.SoluEventos.Dominio;
using Lafrancol.SoluEventos.Soporte.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lafrancol.SoluEventos.Controlador.Controllers
{
    [RoutePrefix("api/proveedor")]
    public class ProveedorController : ApiController
    {
        [HttpGet]
        public ProveedorDto[] GetId(int id)
        {
            return new ProveedorDto[]
           {
                new ProveedorDto
                {
                    id = 1,
                    nombre = "customer-fake"
                }
           };
            
        }
        //public IHttpActionResult GetId(int id)
        //{
        //    var customerFake = "customer-fake";
        //    return Ok(customerFake);
        //}

        [HttpGet]
        public ProveedorDto[] GetAll()
        {
            ProveedorDto[] listaProveedores = new ProveedorDominio().buscarTodos();

            //return new ProveedorDto[]
            //{
            //    new ProveedorDto
            //    {
            //        id = 1,
            //        nombre = "Glenn Block"
            //    },
            //    new ProveedorDto
            //    {
            //        id = 2,
            //        nombre = "Dan Roth"
            //    }
            //};
            return listaProveedores;
        }
    }
}
