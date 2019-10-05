using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Lafrancol.Solu_Eventos.Entidades
{
    public class Proveedor
    {
        private long idProveedor { get; set; }
        private string nit { get; set; }
        private string razonSocial { get; set; }
        private string personaContacto { get; set; }
        private string telefono { get; set; }
        private bool estado { get; set; }
        private string direccion { get; set; }

        public void setId(long idProveedorValor){idProveedor = idProveedorValor;}
        public long getId() { return idProveedor;}

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


        public static Proveedor convertirDtoEnProveedor(ProveedorDto proveedorDtoAConvertir)
        {
            //Recibe una entidad ProveedorDto y devuelve un Proveedor
            Proveedor proveedor = new Proveedor();
            proveedor.idProveedor = proveedorDtoAConvertir.getId();
            proveedor.nit = proveedorDtoAConvertir.getNit();
            proveedor.razonSocial = proveedorDtoAConvertir.getRazonSocial();
            proveedor.personaContacto = proveedorDtoAConvertir.getPersonaContacto();
            proveedor.telefono = proveedorDtoAConvertir.getTelefono();
            proveedor.estado = proveedorDtoAConvertir.getEstado();
            proveedor.direccion = proveedorDtoAConvertir.getDireccion();

            return proveedor;
        }
        
    }
}
