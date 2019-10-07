using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lafrancol.Solu_Eventos.Persistencia.Models;

namespace Lafrancol.Solu_Eventos.Persistencia.Conexion
{
    
    public class SoluDataContext : DbContext
    {

        public SoluDataContext()
            : base("Solu_EventosDB")
        {
        }
        public DbSet<Participante> Students { get; set; }
        //public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{


        //    base.OnModelCreating(modelBuilder);
        //}
        public bool VerifyConnection()
        {

            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=NombreServidor;Initial Catalog=NombreBaseDeDatos;UserID=UsuarioBd;Password=PasswordBd";
            connetionString = "Data Source=salcol-db;Initial Catalog=db_RTVSS;User Id=Desarrolladores;Password=permitido;MultipleActiveResultSets=True;"; 
                //providerName = "System.Data.SqlClient" />
                 cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void Start()
        {
            DbConnection conexion = CreateConnection();
            conexion.Open();
        }
        public virtual DbConnection CreateConnection() {
            string connetionString = null;
            SqlConnection cnn;
            
            connetionString = "Data Source=salcol-db;Initial Catalog=db_RTVSS;User Id=Desarrolladores;Password=permitido;MultipleActiveResultSets=True;";
            cnn = new SqlConnection(connetionString);
            return cnn;
        }
    }
}
