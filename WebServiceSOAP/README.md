# Web Service SOAP: Implementación en Visual Studio 2017

Visual Studio 2017 nos permite crear de manera sencilla y rápida un Web Service, ya que cuenta con una plantilla predeterminada para el mismo. En el proyecto nosotros separaremos la aplicación en tres partes: Conexión a la BD Oracle 11g, creación de procedimientos, main de los Web Methods para el Web Service. 

## Comenzando 

Para iniciar recomendamos instalar todo lo necesario para que la subida del Web Service y la conexión con la BD Oracle 11g sea de manera optima:
1) Instalar ***ODAC for Visual Studio 2017***. Esta es una referencia que permite la conexión con la BD y también el uso de todas sus funciones. _El link de descarga se encuentra en el README del proyecto._
2) Instalar ***Package Newtonsoft.Json (Opcional)***. Si en nuestra salida lo que queremos es un formato JSON, ya que al parecer es más manejable, podemos instalar esta pequeña referencia. _El link de como utilizar la extensión se encuentra en el README del proyecto._
3) Instalar ***Conveyor by Keyoti for Visual Studio 2017***. Cuando desde nuestra aplicación Android llamemos a nuestro Web Service que se creará de manera local, Android no puede acceder a este localhost, para ello utilizamos esta extensión de Visual, que publica, aparte del localhost, el web service en la ip del router al que estes conectado. De esta manera podemos llamarlo desde la aplicación Android sin ningún problema. _El link de descarga se encuentra en el README del proyecto._
4) Para crear mi plantilla de Web Service en Visual Studio 2017 seguí el siguiente tutorial de Microsoft: https://support.microsoft.com/es-pe/help/308359/how-to-write-a-simple-web-service-by-using-visual-c-net


### WebService_Oracle_Connection:

Para poder acceder a todos los comandos que usamos en Visual Studio 2017 para conectarnos a la BD Oracle, primero importamos su referencia que descargamos. 
```
using Oracle.DataAccess.Client;
```
Posteriormente creamos nuestra clase Oracle_Connection, junto con su constructor y un metodo por el cual vamos a establecer la conexión.
* "OracleConnection" creamos un nuevo objeto para poder conectarnos a nuestra BD Oracle.
* "oradb" es un string que debe de tener los siguientes datos necesariamente:
  - DATA SOURCE = localhost:1521/xe 
    - Ingresamos localhost con el puerto 1521 ya que ese puerto viene predeterminado para Oracle, si cambiaste el puerto, tienes que poner el nuevo que tu indicaste.
  - PERSIST SECURITY INFO = True
  - USER ID = UPROCESOS_USER
    - Ingresamos el usuario que se encuentra ligada a la conexión de la base de datos que realizamos en Oracle.
  - PASSWORD = admin
    - Ingresamos el password del usuario que hemos ingresado anteriormente.
* Luego en nuestro objeto "oc" de conexión le decimos que la conexión recibe los parametros de nuestro string.
* Finalmente abrimos la conexión.
  
```
OracleConnection oc;
string oradb = "DATA SOURCE=localhost:1521/xe;PERSIST SECURITY INFO=True;USER ID=UPROCESOS_USER; PASSWORD=admin";
oc = new OracleConnection(oradb);
oc.Open();
```
### WebService_Procedimientos:

Como hemos podido ver en el .sql de procedimientos, tenemos un procedimiento para Insert, Update y Delete de la tabla Administrador y Clientes. 
Más con el Select solo llamamos a la sentencia. Para retornar el Select usamos el comando "DataSet". 
Para usar este comando necesitamos agregar una nueva referencia:
```
using System.Data;
```
Mientras si queremos retornar un string de formato JSON, tenemos que agregar la referencia que descargamos: 
```
using Newtonsoft.Json;
```
Comencemos a explicar un procedimiento que recibe parámetros (Insert,Update,Delete). Recordemos el procedimiento "NEW_ADMIN".
```
CREATE OR REPLACE PROCEDURE NEW_ADMIN(PV1 IN VARCHAR, PV2 IN VARCHAR) AS 
BEGIN
  INSERT INTO ADMINISTRADOR (USUARIO,CONTRASEÑA) VALUES (PV1,PV2);
    EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');
END;
```
Ahora utilizaremos este procedimiento en nuestro Web Service.
* Usamos "OracleParameter" para poder crear un parametro que recibe nuestro procedimiento. Luego le damos el tipo de dato con "OracleDbType y finalmente lo asignamos al nombre de nuestro paramentro.
* "OracleCommand" crea un nuevo comando, a este comando le damos el nombre de nuestro procedimiento en "CommandText", y posteriormente le indicamos que es un Procedure en "CommandType".
* Finalmente con "Parameters.Add" le asignamos los valores de nuestros parametros creados en la parte de arriba.
  - Tener en cuenta que "PV1" y "PV2" tienen el mismo nombre en el procedimiento en Oracle.
* Ejecutamos el procedimiento con "ExecuteNonQuery".
* Cerramos la conexión con "Dispose" y finalmente retornamos la respuesta en el formato JSON.

```
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
```
A diferencia de un procedimiento con parametros, si nosotros queremos hacer un Select, utilizaremos un DataSet.
* Al igual que el anterior creamos nuestro comando, sin embargo, la diferencia es que en "CommandText" le enviamos la sentencia del Select
* El "CommandType" ahora es .Text.
* Ahora creamos un DataSet. 
* Con "OracleDataAdapter" le enviamos nuestro nuestro cmd, que es nuestro comando, finalmente guardamos en da, nuestro DataSet que se llama "ds"
* Retornamos en formato JSON.
```
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
```
