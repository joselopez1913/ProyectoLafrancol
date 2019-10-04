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
        public List<ProveedorDto> GetAll()
        {

            List<Proveedor> listaProveedoresEncontrados = new ProveedorDominio().buscarTodos();
            var listaProveedoresDto = new List<ProveedorDto>();

            //Convierte el listado de Proveedores encontrados en List<ProveedorDto: 
            foreach (Proveedor itemProveedor in listaProveedoresEncontrados)
            {
                ProveedorDto itemDto = ProveedorDto.convertirProveedorADto(itemProveedor);
                listaProveedoresDto.Add(itemDto);
            };



            return listaProveedoresDto;



            //ProveedorDto[] listaProveedores = new ProveedorDominio().buscarTodos();

            //List<ProveedorDto> listaProveedores = new List<ProveedorDto>();
            ////ProveedorDto proveedor01 = new ProveedorDto(1, "Juan");

            //ProveedorDto proveedor01 = new ProveedorDto();
            //proveedor01.id = 1;
            //proveedor01.nombre = "Juan";
            //listaProveedores.Add(proveedor01);

            //ProveedorDto proveedor02 = new ProveedorDto();
            //proveedor02.id = 2;
            //proveedor02.nombre = "Pedro";
            //listaProveedores.Add(proveedor02);


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
            //return listaProveedores;
        }
    }
}
