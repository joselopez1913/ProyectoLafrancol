using Lafrancol.SoluEventos.Dominio;
using Lafrancol.SoluEventos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lafrancol.SoluEventos.Vista.Controllers
{
    [RoutePrefix("api/proveedor") ]
    public class ApiProveedorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult leerProveedores() {
            List<Proveedor> listaProveedoresEncontrados = new ProveedorDominio().buscarTodos();
            var listaProveedoresDto = new List<ProveedorDto>();

            //Convierte el listado de Proveedores encontrados en List<ProveedorDto: 
            foreach (Proveedor itemProveedor in listaProveedoresEncontrados)
            {
                ProveedorDto itemDto = ProveedorDto.convertirProveedorADto(itemProveedor);
                listaProveedoresDto.Add(itemDto);
            };
            return Ok(listaProveedoresDto);
        }
        [HttpPost]
        public IHttpActionResult guardarProveedor(ProveedorDto proveedorAGuardarDto) {
            ProveedorDominio proveedorDominio = new ProveedorDominio();
            Proveedor proveedorGuardado = proveedorDominio.guardar(proveedorAGuardarDto);

            ProveedorDto proveedorGuardadoDto = ProveedorDto.convertirProveedorADto(proveedorGuardado);
            Proveedor proveedorAGuardar = new Proveedor();


            return Ok(proveedorGuardadoDto);
        }
        
    }
}
