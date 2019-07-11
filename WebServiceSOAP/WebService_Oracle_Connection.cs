using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Web.Services;
using Oracle.DataAccess.Types;
using System.Data;
using Newtonsoft.Json;

namespace WcfService2
{
    public class Oracle_conection
    {
        OracleConnection oc;
        string oradb = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=UPROCESOS_USER; PASSWORD=admin"; // establece conexion con el servidor
        public Oracle_conection()
        {
        }

        public void EstablecerConnection ()
        {
            oc = new OracleConnection(oradb);
            oc.Open();
            
        }

        public OracleConnection GetConexion()
        {
            return oc;
        }
    }
}