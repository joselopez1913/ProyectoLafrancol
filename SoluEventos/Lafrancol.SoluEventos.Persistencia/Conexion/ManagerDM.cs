﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;


namespace Lafrancol.SoluEventos.Persistencia.Conexion
{
    public enum nomeCadena
    {
        BD
    }

    internal class ManagerDM
    {
        #region Variables

        string nomeCadenaBancoDoDados;

        #endregion

        #region Constructores

        /// <summary>
        /// Asigna el nombre de la cadena de conexión cuando no se recibe como parametro.
        /// </summary>
        public ManagerDM()
        {
            nomeCadenaBancoDoDados = "strConnectionRVSST";
            baseDatos = new DatabaseProviderFactory().Create(obtenerNombreCadenaBaseDatos(nomeCadenaBancoDoDados));
        }

        #endregion     

        #region Atributos

        ///// <summary>
        ///// Objeto para conectar a la base de datos.
        ///// </summary>       
        private Database baseDatos;

        ///// <summary>
        ///// Objeto para almacenar una transacción de base de datos.
        ///// </summary>
        private IDbTransaction transaccion;

        ///// <summary>
        /// Objeto para dar contexto a una transacción.
        /// </summary>
        private DbConnection connection;

        #endregion   

        #region Métodos
        /// <summary>
        /// Ejecuta un procedimiento almacenado.
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento.</param>
        /// <returns>Retorna la cantidad de registros afectados.</returns>
        /// <author>"Alexander Gonzalez Valencia"</author>
        public int EjecutarNonQuery(string procedimiento, List<Parameter> listParametros)
        {
            DbCommand comando = prepararComando(procedimiento) as DbCommand;
            establecerParametros(listParametros, comando);
            int result = baseDatos.ExecuteNonQuery(comando);
            obtenerParametros(listParametros, comando);
            return result;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado.
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento.</param>
        /// <returns>Retorna un valor de tipo object.</returns>
        /// <author>"Alexander Gonzalez Valencia"</author>
        public object EjecutarScalar(string procedimiento, List<Parameter> listParametros)
        {
            object respuesta = null;
            DbCommand comando = prepararComando(procedimiento) as DbCommand;
            establecerParametros(listParametros, comando);
            respuesta = baseDatos.ExecuteScalar(comando);
            obtenerParametros(listParametros, comando);
            return respuesta;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado.
        /// </summary>
        /// <returns>Retorna un Reader con los datos recuperados.</returns>
        /// <param name="procedimiento">Nombre del procedimiento.</param>
        /// <returns>Retorna un DataReader.</returns>
        /// <author>"Alexander Gonzalez Valencia"</author>
        public IDataReader EjecutarReader(string procedimiento, List<Parameter> listParametros)
        {
            DbCommand comando = prepararComando(procedimiento) as DbCommand;
            establecerParametros(listParametros, comando);

            IDataReader reader;
            bool transaccionIniciada = (transaccion != null) && (connection != null) && (connection.State == ConnectionState.Open);
            if (transaccionIniciada)
            {
                reader = baseDatos.ExecuteReader(comando, (DbTransaction)transaccion);
            }
            else
            {
                reader = baseDatos.ExecuteReader(comando);
            }

            obtenerParametros(listParametros, comando);

            return reader;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y lo llena en un data set
        /// con parametro.  
        /// </summary>
        /// <returns>Retorna un DataSet con los datos recuperados.</returns>
        /// <param name="procedimiento">Nombre del procedimiento.</param>
        /// <returns>Retorna un DataSet.</returns>
        public DataSet EjecutarDataSet(string procedimiento, List<Parameter> listParametros)
        {
            DbCommand comando = prepararComando(procedimiento) as DbCommand;
            establecerParametros(listParametros, comando);
            DataSet datos = baseDatos.ExecuteDataSet(comando);
            obtenerParametros(listParametros, comando);
            return datos;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y lo llena en un data set
        /// sin parametro.  
        /// </summary>
        /// <returns>Retorna un DataSet con los datos recuperados.</returns>
        /// <param name="procedimiento">Nombre del procedimiento.</param>
        /// <returns>Retorna un DataSet.</returns>
        public DataSet EjecutarDataSet(string procedimiento)
        {
            DbCommand comando = prepararComando(procedimiento) as DbCommand;
            DataSet datos = baseDatos.ExecuteDataSet(comando);
            return datos;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado con parametros y lo llena en un datatable. 
        /// </summary>
        /// <param name="procedimiento">procedimento que se vai executar</param>
        /// <param name="_DTParametro">parametros sem tipar</param>
        /// <returns></returns>
        public DataTable ejecutarDataSetWithDataTable(string procedimiento, List<Parameter> listParametros)
        {
            SqlCommand comando = prepararComando(procedimiento) as SqlCommand;
            establecerParametros(listParametros, comando);
            DataTable datos = baseDatos.ExecuteDataSet(comando).Tables[0];
            //ObtenerParametros(listParametros, comando);
            return datos;
        }
        public DataTable ejecutarDataSetWithDataTableP(string procedimiento)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = procedimiento;
            command.CommandTimeout = 15;
            command.CommandType = CommandType.Text;
            
            DataTable datos = baseDatos.ExecuteDataSet(command).Tables[0];
            return datos;
        }
        public DataTable ejecutarScalar(string procedimiento)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = procedimiento;
            comando.CommandTimeout = 15;
            comando.CommandType = CommandType.Text;

            
            
            DataTable datos = baseDatos.ExecuteDataSet(comando).Tables[0];
            
            return datos;
        }


        /// <summary> 
        /// Ejecuta un procedimiento almacenado sin parametros y lo llena en un datatable. 
        /// </summary>
        /// <param name="procedimiento">procedimento que se vai executar</param>        
        /// <returns></returns>
        public DataTable ejecutarDataSetWithDataTable(string procedimiento)
        {
            SqlCommand comando = prepararComando(procedimiento) as SqlCommand;
            DataTable datos = baseDatos.ExecuteDataSet(comando).Tables[0];
            return datos;
        }


        /// <summary>
        /// Inicia una transacción de base de datos.
        /// </summary>
        /// <returns>Retornar una transacción de base de datos.</returns>
        public IDbTransaction IniciarTransaccion()
        {
            connection = baseDatos.CreateConnection();
            connection.Open();
            transaccion = connection.BeginTransaction();
            return transaccion;
        }

        /// <summary>
        /// Finaliza una transacción de base de datos.
        /// </summary>
        public void FinalizarTransaccion()
        {
            if (transaccion.Connection != null)
            {
                transaccion.Commit();
            }

            if ((connection != null) && (connection.State == ConnectionState.Open))
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Permite almacenar un archivo en la base de datos.
        /// </summary>
        /// <param name="path">Ruta física del archivo en el servidor.</param>
        /// <param name="contenidoArchivo">Binarios del archivo.</param>
        /// <param name="longitudArchivo">Tamaño del archivo.</param>
        public void ejecutarWriteFileStream(string path, IList<byte> contenidoArchivo, int longitudArchivo)
        {
            byte[] objContext = obtenerContextoFileStream();
            using (SqlFileStream objSqlFileStream = new SqlFileStream(path, objContext, FileAccess.Write))
            {
                byte[] objContenido = contenidoArchivo.ToArray();
                objSqlFileStream.Write(objContenido, 0, longitudArchivo);
            }
        }

        /// <summary>
        /// Permite obtener un archivo en la base de datos.
        /// </summary>
        /// <param name="path">Ruta física del archivo en el servidor.</param>
        /// <returns>Retorna el contenido de un archivo.</returns>
        public byte[] ejecutarReadFileStream(string path)
        {
            byte[] buffer = null;
            byte[] objContext = obtenerContextoFileStream();
            using (SqlFileStream objSqlFileStream = new SqlFileStream(path, objContext, FileAccess.Read))
            {
                buffer = new byte[(int)objSqlFileStream.Length];
                objSqlFileStream.Read(buffer, 0, buffer.Length);
            }

            return buffer;
        }

        /// <summary>
        /// Obtiene la cadena de conexión a la base de datos.
        /// </summary>
        /// <returns>Retorna el connection string de la base de datos.</returns>
        /// <author>"Alexander Gonzalez Valencia"</author>
        private static string obtenerNombreCadenaBaseDatos(string nomeCadenaBancoDoDados)
        {
            return ConfigurationManager.ConnectionStrings[nomeCadenaBancoDoDados].Name;
            //return "Data Source=salcol-db;Initial Catalog=db_RTVSS;User Id=Desarrolladores;Password=permitido;MultipleActiveResultSets=True;providerName=System.Data.SqlClient";
        }

        /// <summary>
        /// Permite obtener el contexto de una transacción de FileStream.
        /// </summary>
        /// <returns>Retorna el contexto de la transacción para FileStream</returns>
        private byte[] obtenerContextoFileStream()
        {
            using (SqlCommand objSqlCmdFS = new SqlCommand("SELECT GET_FILESTREAM_TRANSProjetoION_CONTEXT()", (SqlConnection)connection, (SqlTransaction)transaccion))
            {
                byte[] objContext = (byte[])objSqlCmdFS.ExecuteScalar();
                return objContext;
            }
        }

        /// <summary>
        /// Permite crear un objeto IDbCommand con el procedimiento que se suminitra.
        /// </summary>
        /// <returns>Retorna un comando.</returns>
        /// <param name="procedimiento">Nombre del procedimiento.</param>
        /// <returns></returns>
        /// <author>"Alexander Gonzalez Valencia"</author>
        private IDbCommand prepararComando(string procedimiento)
        {
            DbCommand comando = baseDatos.GetStoredProcCommand(procedimiento);

            //comando.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["TimeoutBD"].ToString());
            return comando;
        }

        /// <summary>
        /// Estable los parametros de un comando de Base de datos
        /// </summary>
        /// <param name="listParametros"></param>
        /// <param name="cmd"></param>
        private static void establecerParametros(List<Parameter> listParametros, DbCommand cmd)
        {
            if (listParametros != null)
            {
                DbParameter param;
                for (int index = 0; index < listParametros.Count; index++)
                {
                    param = cmd.CreateParameter();
                    Parameter itemParam = listParametros[index];
                    param.ParameterName = itemParam.Nombre;
                    param.Value = itemParam.Valor;
                    if (itemParam.Direccion == ParameterDirection.Output || itemParam.Direccion == ParameterDirection.InputOutput)
                    {
                        param.Direction = itemParam.Direccion;
                        param.Size = itemParam.Tamano;
                    }
                    cmd.Parameters.Add(param);
                }
            }
        }

        /// <summary>
        /// Obtiene los parametros de salida de un procedimiento
        /// </summary>
        /// <param name="listParametros"></param>
        /// <param name="cmd"></param>
        private static void obtenerParametros(List<Parameter> listParametros, DbCommand cmd)
        {
            if (listParametros != null)
            {
                for (int index = 0; index < listParametros.Count; index++)
                {
                    Parameter itemParam = listParametros[index];
                    if (itemParam.Direccion == ParameterDirection.Output || itemParam.Direccion == ParameterDirection.InputOutput)
                    {
                        itemParam.Valor = cmd.Parameters[index].Value;
                    }
                }
            }
        }
        #endregion
    }
}
