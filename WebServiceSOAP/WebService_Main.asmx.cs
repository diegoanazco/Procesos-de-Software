using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
using Newtonsoft.Json;


namespace WcfService2
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        private
            Procedimientos pc;

       /*PESTAÑA LOGIN*/

        [WebMethod]
        public string Admin_Login( string usuario, string contrasena)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Admin_Login_Pro(conn.GetConexion(),usuario,contrasena);
          
        }

        /*PESTAÑA ADMINISTRADORES*/
         
        [WebMethod]
        public string Admin_New( string usuario, string contrasena)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Admin_New_Pro(conn.GetConexion(), usuario, contrasena);
        }

        [WebMethod]
        public string Admin_Drop(string usuario)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Admin_Drop_Pro(conn.GetConexion(), usuario);

        }

        [WebMethod]
        public string Admin_Update(string usuario, string contrasena)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Admin_Update_Pro(conn.GetConexion(), usuario, contrasena);

        }


        [WebMethod]
        public string Admin_Select_Full()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Admin_Select_Full_Pro(conn.GetConexion());
        }


        [WebMethod]
        public string Admin_Select()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Admin_Select_Pro(conn.GetConexion());

        }

        /*METODOS CLIENTES*/
               

        [WebMethod]
        public string Clientes_Select()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Clientes_Select_Pro(conn.GetConexion());
     
        }

        [WebMethod]
        public string Clientes_New(string id, string nombre, string direccion, string idpais, string telefono, float linea_credito)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Clientes_New_Pro(conn.GetConexion(),id, nombre, direccion, idpais, telefono, linea_credito);
        }

        [WebMethod]
        public string Clientes_Find(string nombre)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Clientes_Find_Pro(conn.GetConexion(), nombre);

        }

        [WebMethod]
        public string Clientes_Drop(string id)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();

            return pc.Clientes_Drop_Pro(conn.GetConexion(), id);
        }

        [WebMethod]
        public string Clientes_Update(string id,  float linea_credito)
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();
            return pc.Clientes_Update_Pro(conn.GetConexion(), id, linea_credito);
        }

        /*METODOS EMPLEADOS*/

        [WebMethod]
        public string Empleados_Select()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();
            return pc.Empleados_Select_Pro(conn.GetConexion());
        }



        /*METODOS PAISES*/
                     

        [WebMethod]
        public string Paises_Select()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();
            return pc.Paises_Select_Pro(conn.GetConexion());
        }

        [WebMethod]
        public string Distritos_Select()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();
            return pc.Distritos_Select_Pro(conn.GetConexion());
        }

        [WebMethod]
        public string Cargos_Select()
        {
            Oracle_conection conn = new Oracle_conection();
            conn.EstablecerConnection();

            Procedimientos pc = new Procedimientos();
            return pc.Cargos_Select_Pro(conn.GetConexion());
        }


    }
}
