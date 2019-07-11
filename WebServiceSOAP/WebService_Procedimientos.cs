using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using Newtonsoft.Json;
using System.Data;

namespace WcfService2
{
    public class Procedimientos
    {
        
        public Procedimientos()
        {
            
        }

        public string Admin_Login_Pro(OracleConnection conn, string usuario, string contrasena)
        {
           
            OracleParameter param_usuario = new OracleParameter();
            param_usuario.OracleDbType = OracleDbType.Varchar2;
            param_usuario.Value = usuario;

            OracleParameter param_contrasena = new OracleParameter();
            param_contrasena.OracleDbType = OracleDbType.Varchar2;
            param_contrasena.Value = contrasena;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "LOGIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_usuario.Value;
            cmd.Parameters.Add("PV2", OracleDbType.Varchar2).Value = param_contrasena.Value;
            cmd.Parameters.Add("PS1", OracleDbType.Int16).Direction = System.Data.ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            string respuesta;
            respuesta = cmd.Parameters["PS1"].Value.ToString();
            conn.Dispose();

            return respuesta;
        }

        public string Admin_New_Pro(OracleConnection conn, string usuario, string contrasena)
        {
            
            OracleParameter param_usuario = new OracleParameter();
            param_usuario.OracleDbType = OracleDbType.Varchar2;
            param_usuario.Value = usuario;

            OracleParameter param_contrasena = new OracleParameter();
            param_contrasena.OracleDbType = OracleDbType.Varchar2;
            param_contrasena.Value = contrasena;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "NEW_ADMIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_usuario.Value;
            cmd.Parameters.Add("PV2", OracleDbType.Varchar2).Value = param_contrasena.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Administrador creado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }
        public string Admin_Drop_Pro(OracleConnection conn, string usuario)
        {
            OracleParameter param_usuario = new OracleParameter();
            param_usuario.OracleDbType = OracleDbType.Varchar2;
            param_usuario.Value = usuario;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DROP_ADMIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_usuario.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Administrador eliminado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Admin_Update_Pro(OracleConnection conn, string usuario, string contrasena)
        {
            

            OracleParameter param_usuario = new OracleParameter();
            param_usuario.OracleDbType = OracleDbType.Varchar2;
            param_usuario.Value = usuario;

            OracleParameter param_contrasena = new OracleParameter();
            param_contrasena.OracleDbType = OracleDbType.Varchar2;
            param_contrasena.Value = contrasena;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE_ADMIN";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_usuario.Value;
            cmd.Parameters.Add("PV2", OracleDbType.Varchar2).Value = param_contrasena.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Contraseña actualizada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Admin_Select_Full_Pro(OracleConnection conn)
        {
            

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT ID,USUARIO,CONTRASEÑA FROM ADMINISTRADOR";
            cmd.CommandType = System.Data.CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        public string Admin_Select_Pro(OracleConnection conn)
        {
            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT ID,USUARIO FROM ADMINISTRADOR";
            cmd.CommandType = System.Data.CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        public string Clientes_Select_Pro(OracleConnection conn)
        {
           
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT C.IDCLIENTE,C.NOMCLIENTE,C.DIRCLIENTE,C.IDPAIS,P.NOMBREPAIS,C.FONOCLIENTE,C.LINEACREDI FROM CLIENTES C INNER JOIN PAISES P ON C.IDPAIS = P.IDPAIS";
            cmd.CommandType = System.Data.CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        public string Clientes_New_Pro(OracleConnection conn, string id, string nombre, string direccion, string idpais, string telefono, float linea_credito)
        {
            

            OracleParameter param_id = new OracleParameter();
            param_id.OracleDbType = OracleDbType.Varchar2;
            param_id.Value = id;

            OracleParameter param_nombre = new OracleParameter();
            param_nombre.OracleDbType = OracleDbType.Varchar2;
            param_nombre.Value = nombre;

            OracleParameter param_direccion = new OracleParameter();
            param_direccion.OracleDbType = OracleDbType.Varchar2;
            param_direccion.Value = direccion;

            OracleParameter param_idpais = new OracleParameter();
            param_idpais.OracleDbType = OracleDbType.Varchar2;
            param_idpais.Value = idpais;

            OracleParameter param_telefono = new OracleParameter();
            param_telefono.OracleDbType = OracleDbType.Varchar2;
            param_telefono.Value = telefono;

            OracleParameter param_linea_credito = new OracleParameter();
            param_linea_credito.OracleDbType = OracleDbType.Varchar2;
            param_linea_credito.Value = linea_credito;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "CLIENTES_NEW";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_id.Value;
            cmd.Parameters.Add("PV2", OracleDbType.Varchar2).Value = param_nombre.Value;
            cmd.Parameters.Add("PV3", OracleDbType.Varchar2).Value = param_direccion.Value;
            cmd.Parameters.Add("PV4", OracleDbType.Varchar2).Value = param_idpais.Value;
            cmd.Parameters.Add("PV5", OracleDbType.Varchar2).Value = param_telefono.Value;
            cmd.Parameters.Add("PV6", OracleDbType.BinaryFloat).Value = param_linea_credito.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Cliente insertado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Clientes_Find_Pro(OracleConnection conn,string nombre)
        {
            

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT *FROM CLIENTES WHERE NOMCLIENTE = '" + nombre + "'";
            cmd.CommandType = System.Data.CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        public string Clientes_Drop_Pro(OracleConnection conn,string id)
        {

            OracleParameter param_id = new OracleParameter();
            param_id.OracleDbType = OracleDbType.Varchar2;
            param_id.Value = id;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "CLIENTES_DROP";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_id.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Cliente eliminado";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Clientes_Update_Pro(OracleConnection conn,string id, float linea_credito)
        {
            

            OracleParameter param_id = new OracleParameter();
            param_id.OracleDbType = OracleDbType.Varchar2;
            param_id.Value = id;

            OracleParameter param_linea_credito = new OracleParameter();
            param_linea_credito.OracleDbType = OracleDbType.Varchar2;
            param_linea_credito.Value = linea_credito;


            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "CLIENTES_UPDATE_LINCREDI";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("PV1", OracleDbType.Varchar2).Value = param_id.Value;
            cmd.Parameters.Add("PV2", OracleDbType.BinaryFloat).Value = param_linea_credito.Value;
            cmd.ExecuteNonQuery();

            string respuesta = "Linea de Credito actualizada";
            conn.Dispose();

            return JsonConvert.SerializeObject(respuesta, Newtonsoft.Json.Formatting.Indented);
        }

        public string Empleados_Select_Pro(OracleConnection conn)
        {
            

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT E.IDEMPLEADO,E.APEEMPLEADO,E.NOMEMPLEADO,E.FECNAC,E.DIREEMPLEADO,E.IDDISTRITO,D.NOMDISTRITO,E.FONOEMPLEADO,E.IDCARGO,C.DESCARGO,E.FECCONTRATA,E.SALARY FROM EMPLEADOS E INNER JOIN DISTRITOS D ON D.IDDISTRITO = E.IDDISTRITO INNER JOIN CARGOS C ON C.IDCARGO = E.IDCARGO";
            cmd.CommandType = System.Data.CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        public string Paises_Select_Pro(OracleConnection conn)
        {
            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT *FROM PAISES";
            cmd.CommandType = System.Data.CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        public string Distritos_Select_Pro(OracleConnection conn)
        {
            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT *FROM DISTRITOS";
            cmd.CommandType = System.Data.CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }

        public string Cargos_Select_Pro(OracleConnection conn)
        {
            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT *FROM CARGOS";
            cmd.CommandType = System.Data.CommandType.Text;


            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented);
        }





    }
}