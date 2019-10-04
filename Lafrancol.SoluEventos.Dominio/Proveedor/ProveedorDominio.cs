using Lafrancol.SoluEventos.Soporte.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lafrancol.SoluEventos.Dominio
{
    public class ProveedorDominio
    {
        public List<Proveedor> buscarTodos()
        {
            //ProveedorRepository proveedorRepository = new ProveedorRepository();
            //List<Proveedor> listaProveedores = proveedorRepository.buscarTodos();
            //List<Proveedor> listaProveedores = 

            //return listaProveedores;

            List<Proveedor> listaProveedores = new List<Proveedor>();
            //ProveedorDto proveedor01 = new ProveedorDto(1, "Juan");

            Proveedor proveedor01 = new Proveedor();
            proveedor01.setId(1);
            proveedor01.setRazonSocial("Juan08");
            listaProveedores.Add(proveedor01);

            Proveedor proveedor02 = new Proveedor();
            proveedor02.setId(2);
            proveedor02.setRazonSocial("Pedro08");
            listaProveedores.Add(proveedor02);

            return listaProveedores;
        }

        //public Proveedor guardar(ProveedorDto proveedorAGuardarDto)
        //{
        //    //ProveedorRepository proveedorRepository = new ProveedorRepository();
        //    Proveedor proveedorAGuardar = Proveedor.convertirDtoEnProveedor(proveedorAGuardarDto);
        //    Proveedor proveedorGuardado = proveedorRepository.guardar(proveedorAGuardar);
        //    return proveedorGuardado;
        //}
    }
}
