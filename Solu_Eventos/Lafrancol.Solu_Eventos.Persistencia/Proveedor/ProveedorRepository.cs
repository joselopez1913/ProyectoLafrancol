using Lafrancol.Solu_Eventos.Entidades;
using Lafrancol.Solu_Eventos.Persistencia.Conexion;
using Lafrancol.Solu_Eventos.Transversal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lafrancol.Solu_Eventos.Persistencia.ProveedorRepository
{
    public class ProveedorRepository
    {
        private ManagerDM accesoDatos;
        private List<Parameter> parametros;

        public ProveedorRepository()
        {
            accesoDatos = new ManagerDM();
            parametros = new List<Parameter>();
        }

        public List<Proveedor> buscarTodos()
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            DataTable dtProveedores = accesoDatos.ejecutarDataSetWithDataTableP("SELECT * FROM [dbo].[tbProveedor]");
            listaProveedores = ConvertData.ConvertirDtoToListPrivate<Proveedor>(dtProveedores);
            return listaProveedores;
        }

        public Proveedor guardar(Proveedor proveedorAGuardar)
        {

            DataTable dtProveedoresGuardados = accesoDatos.ejecutarDataSetWithDataTableP("DECLARE @new_identity INT; INSERT INTO [dbo].[tbProveedor] (razonSocial,nit,personaContacto,telefono,direccion, estado)" +
            "VALUES('" + proveedorAGuardar.getRazonSocial() + "', '" + proveedorAGuardar.getNit() + "', '" + proveedorAGuardar.getPersonaContacto() + "', '" + proveedorAGuardar.getTelefono() + "', '" + proveedorAGuardar.getDireccion() + "', '1'); " +
            "SET @new_identity = SCOPE_IDENTITY();" +
            "SELECT * FROM [dbo].[tbProveedor] WHERE idProveedor=@new_identity; ");

            List<Proveedor> listaProveedoresConvertidos = ConvertData.ConvertirDtoToList<Proveedor>(dtProveedoresGuardados);
            Proveedor proveedorGuardado = listaProveedoresConvertidos[0];
            return proveedorGuardado;
        }
    }
}
