using Lafrancol.SoluEventos.Soporte.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Lafrancol.SoluEventos.Vista.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            IEnumerable<ProveedorDto> proveedoresRecibidos = null;
            List<ProveedorDtoVisualizacion> proveedoresAEnviar = new List<ProveedorDtoVisualizacion>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51777/api/");
                //HTTP GET
                var responseTask = client.GetAsync("proveedor");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProveedorDto>>();
                    readTask.Wait();

                    proveedoresRecibidos = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    proveedoresRecibidos = Enumerable.Empty<ProveedorDto>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
                
             
            }
            foreach (ProveedorDto itemProveedor in proveedoresRecibidos)
            {
                //var item = proveedoresRecibidos.Cast<ProveedorDto>().ElementAt(0);
                ProveedorDtoVisualizacion proveedorVista = new ProveedorDtoVisualizacion();
                proveedorVista = ProveedorDtoVisualizacion.conertirDtoAVisualizacion(itemProveedor);
                proveedoresAEnviar.Add(proveedorVista);
            }
            return View(proveedoresRecibidos);
        }

        public ActionResult guardarProveedor()
        {
            var proveedor = new ProveedorDto() { nombre = "John" };
            using (var client = new HttpClient())
            {
                var postTask = client.PostAsJsonAsync<ProveedorDto>("proveedor", proveedor);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<ProveedorDto>();
                    readTask.Wait();

                    var insertedEmployee = readTask.Result;

                    Console.WriteLine("Employee {0} inserted with id: {1}", insertedEmployee.nombre, insertedEmployee.id);
                }
                //else
                //{
                //    Console.WriteLine(result.StatusCode);
                //}
                return View();
            }
        }

        public ActionResult leerUnProveedor()
        {
            IEnumerable<ProveedorDto> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51777/api/");
                //HTTP GET
                var responseTask = client.GetAsync("proveedor/GetId?id=1");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ProveedorDto>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<ProveedorDto>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(students);
        }
    }
}