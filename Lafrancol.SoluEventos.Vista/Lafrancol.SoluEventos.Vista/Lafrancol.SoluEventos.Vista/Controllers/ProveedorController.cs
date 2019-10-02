using Lafrancol.SoluEventos.Soporte.Dto;
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
            IEnumerable<ProveedorDto> students = null;

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