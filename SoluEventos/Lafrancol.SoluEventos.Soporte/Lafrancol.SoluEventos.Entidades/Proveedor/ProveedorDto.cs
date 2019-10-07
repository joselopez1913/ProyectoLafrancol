using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lafrancol.SoluEventos.Entidades
{
    public class ProveedorDto

    {
        public long idProveedor { get; set; }
        public string nit { get; set; }
        public string razonSocial { get; set; }
        public string personaContacto { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }
        public string direccion { get; set; }

        public void setId(long idProveedorValor) { idProveedor = idProveedorValor; }
        public long getId() { return idProveedor; }

        public void setNit(string nitValor) { nit = nitValor; }
        public string getNit() { return nit; }

        public void setRazonSocial(string razonSocialValor) { razonSocial = razonSocialValor; }
        public string getRazonSocial() { return razonSocial; }

        public void setPersonaContacto(string personaContactoValor) { personaContacto = personaContactoValor; }
        public string getPersonaContacto() { return personaContacto; }

        public void setTelefono(string telefonoValor) { telefono = telefonoValor; }
        public string getTelefono() { return telefono; }

        public void setEstado(bool estadoValor) { estado = estadoValor; }
        public bool getEstado() { return estado; }

        public void setDireccion(string direccionValor) { direccion = direccionValor; }
        public string getDireccion() { return direccion; }


        public static ProveedorDto convertirProveedorADto(Proveedor proveedorAConvertir)
        {
            //Recibe una entidad Proveedor y devuelve un ProveedorDto
            ProveedorDto proveedorDto = new ProveedorDto();

            proveedorDto.idProveedor = proveedorAConvertir.getId();
            proveedorDto.nit = proveedorAConvertir.getNit();
            proveedorDto.razonSocial = proveedorAConvertir.getRazonSocial();
            proveedorDto.personaContacto = proveedorAConvertir.getPersonaContacto();
            proveedorDto.telefono = proveedorAConvertir.getTelefono();
            proveedorDto.estado = proveedorAConvertir.getEstado();
            proveedorDto.direccion = proveedorAConvertir.getDireccion();

            
            return proveedorDto;
        }
    }
}
