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
        public ProveedorDto[] buscarTodos()
        {
            //ProveedorRepository proveedorRepository = new ProveedorRepository();
            //List<Proveedor> listaProveedores = proveedorRepository.buscarTodos();
            //List<Proveedor> listaProveedores = 

            //return listaProveedores;

            return new ProveedorDto[]
            {
                new ProveedorDto
                {
                    id = 1,
                    nombre = "Glenn Block5"
                },
                new ProveedorDto
                {
                    id = 2,
                    nombre = "Dan Roth5"
                }
            };
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
