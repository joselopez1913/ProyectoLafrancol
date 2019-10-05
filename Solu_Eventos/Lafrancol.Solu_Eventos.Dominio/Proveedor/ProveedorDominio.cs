using Lafrancol.Solu_Eventos.Entidades;
using Lafrancol.Solu_Eventos.Persistencia.ProveedorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.ProveedorDominio
{
    public class ProveedorDominio
    {
        public List<Proveedor> buscarTodos()
        {
            ProveedorRepository proveedorRepository = new ProveedorRepository();
            List<Proveedor> listaProveedores = proveedorRepository.buscarTodos();

            return listaProveedores;
        }

        public Proveedor guardar(ProveedorDto proveedorAGuardarDto)
        {
            ProveedorRepository proveedorRepository = new ProveedorRepository();
            Proveedor proveedorAGuardar = Proveedor.convertirDtoEnProveedor(proveedorAGuardarDto);
            Proveedor proveedorGuardado = proveedorRepository.guardar(proveedorAGuardar);
            return proveedorGuardado;
        }
    }
}
