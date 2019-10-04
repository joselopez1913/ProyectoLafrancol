using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lafrancol.SoluEventos.Soporte.Entidades
{
    public class ProveedorDtoVisualizacion
    {
        public long id { get; set; }
        public string nit { get; set; }
        public string nombre { get; set; }
        public string personaContacto { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }
        public string direccion { get; set; }


        public static ProveedorDtoVisualizacion conertirDtoAVisualizacion(ProveedorDto proveedorDtoAConvertir) { 
            ProveedorDtoVisualizacion proveedorConvertido = new ProveedorDtoVisualizacion();
            proveedorConvertido.id = proveedorDtoAConvertir.getId();
            proveedorConvertido.nit = proveedorDtoAConvertir.getNit();
            proveedorConvertido.nombre = proveedorDtoAConvertir.getRazonSocial();
            proveedorConvertido.personaContacto = proveedorDtoAConvertir.getPersonaContacto();
            proveedorConvertido.telefono = proveedorDtoAConvertir.getTelefono();
            proveedorConvertido.estado = proveedorDtoAConvertir.getEstado();
            proveedorConvertido.direccion = proveedorDtoAConvertir.getDireccion();

            return proveedorConvertido;
        }
    }
}
