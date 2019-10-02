using Lafrancol.SoluEventos.Soporte.Dto;
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
        public IHttpActionResult GetId(int id)
        {
            var customerFake = "customer-fake";
            return Ok(customerFake);
        }

        [HttpGet]
        public ProveedorDto[] GetAll()
        {
            return new ProveedorDto[]
            {
                new ProveedorDto
                {
                    id = 1,
                    nombre = "Glenn Block"
                },
                new ProveedorDto
                {
                    id = 2,
                    nombre = "Dan Roth"
                }
            };
        }
    }
}
