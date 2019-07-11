# Web Service SOAP: Implementación en Visual Studio 2017

Visual Studio 2017 nos permite crear de manera sencilla y rápida un Web Service, ya que cuenta con una plantilla predeterminada para el mismo. En el proyecto nosotros separaremos la aplicación en tres partes: Conexión a la BD Oracle 11g, creación de procedimientos, main de los Web Methods para el Web Service. 

## Comenzando 

Para iniciar recomendamos instalar todo lo necesario para que la subida del Web Service y la conexión con la BD Oracle 11g sea de manera optima:
1) Instalar ***ODAC for Visual Studio 2017***. Esta es una referencia que permite la conexión con la BD y también el uso de todas sus funciones. _El link de descarga se encuentra en el README del proyecto._
2) Instalar ***Package Newtonsoft.Json (Opcional)***. Si en nuestra salida lo que queremos es un formato JSON, ya que al parecer es más manejable, podemos instalar esta pequeña referencia. _El link de como utilizar la extensión se encuentra en el README del proyecto._
3) Instalar ***Conveyor by Keyoti for Visual Studio 2017***. Cuando desde nuestra aplicación Android llamemos a nuestro Web Service que se creará de manera local, Android no puede acceder a este localhost, para ello utilizamos esta extensión de Visual, que publica, aparte del localhost, el web service en la ip del router al que estes conectado. De esta manera podemos llamarlo desde la aplicación Android sin ningún problema. _El link de descarga se encuentra en el README del proyecto._


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
  



