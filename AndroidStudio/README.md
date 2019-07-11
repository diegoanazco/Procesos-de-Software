# Aplicación Android: Implementación en Android Studio

Android Studio nos permite crear aplicaciones para dispositivos moviles Android, encontramos muchos tutoriales en internet de como mejorar la interfaz, para este proyecto lo que nos importa es que consuma el Web Service ya creado desde Visual Studio, y gracias a ellos crear cada pestaña de nuestra aplicación. En este caso, usaremos como ejemplo el procedimiento Login, ya que todas las demás llamadas son muy parecidas.  

## Comenzando 

Para poder consumir el servicio Web Service sin ningún problema necesitamos:
1) Instalar la libreria ***Ksoap2 3.0.0 para Android Studio***. Esta librería nos permite consumir un Web Service SOAP (Que tiene un WSDL), no solo del que hemos creado, si no cualquiera que se encuentre en la red._El link de descarga se encuentra en el README del proyecto._ 

### AndroidManifest.xml:

Para poder consumir servicios de internet necesitamos modificar nuestro archivo AndroidManifest.xml, que se encuentra en: Androdi/app/manifest/AndroidManifest.xml en nuestro proyecto. 
* Debemos permitir que android pueda usar INTERNET para consumir un web service que se encuentra en la red o en un localhost o una ip local.
```
<uses-permission android:name="android.permission.INTERNET" />
```
* Después de darle permisos, tenemos que limpiar el trafico, lo hacemos con la siguiente sentencia dentro de <application
```
android:usesCleartextTraffic="true">
```
### Activity_main.xml:

Les dejo la interfaz del login para que se puedan guiar mejor al entender el proyecto y la conexión. Para saber el nombre de los textview, botones, plaintext, etc.

### MainActivity.java:

Desde Android Studio 3.0 a más es necesario introducir todo nuestro código dentro de un hilo (Thread) por ello comenzamos creando nuestro hilo y dentro de el mismo todo nuestro código. 
```
Thread nt = new Thread()
```
Dentro del thread asignamos nuestros EditText para el usuario y contraseña a nuestros objetos xml de la siguiente manera: 
```
EditText usuario = (EditText)findViewById(R.id.login_Usuario);
EditText password = (EditText)findViewById(R.id.login_Password_X);
```
Luego creamos nuestra clase "run" donde dentro de ella tendrá nuestra llamada al web service, como también su uso. 
Los siguientes string los hemos sacado de la documentación del web service, en el .asmx. Estos valores cambian de acuerdo al método del web service. 
* String NAMESPACE
  - El Web Service que creamos en Visual Studio 2017 nos crea por defecto en la siguiente url: tempuri.org
* String URL
  - Como vimos con anterioridad, utilizamos el Conveyor en Visual Studio para poder generar la ip del router que estamos conectados actualmente. Si le pasamos el localhost, Android no lo reconocera, por lo cual usamos la ip y puerto que Conveyor de Visual Studio nos ha generado, junto con el nombre del WebService.
* String METHOD_NAME
  - Lo asignamos al nombre de nuestro procedimiento que esta en Visual Studio 2017
* String SOAP_ACTION
  - Si observamos con cuidado, el SOAP_ACTION es la unión entre NAMESPACE y el METHOD_NAME.
```
String NAMESPACE = "http://tempuri.org/";
String URL = "http://192.168.22.206:45455//WebService1.asmx";
String METHOD_NAME = "Admin_Login";
String SOAP_ACTION = "http://tempuri.org/Admin_Login";
```
Al tener un procedimiento con parametros, necesitamos ingresarlos, en este caso los parametros son usuarios y contraseña. Estos datos los vamos a obtener de nuestros EditText.
* SoapObject request
  - Creamos un objeto SOAP que recibe nuestro NAMESPACE y nuestro METHOD_NAME.
* request.addProperty
  - La siguiente función recibe dos parámetros:
    - El primer parametro se obtiene de la documentación del web service, en nuestro caso es el siguiente. 
      ```
        <usuario> string <usuario>
        <contrasena> string <contrasena>
      ```
    - Mientras que el segundo parametro lo obtenemos de lo que ingresemos en nuestro EditText, al ser de tipo String, lo convertimos en el mismo.
```
SoapObject request = new SoapObject(NAMESPACE,METHOD_NAME);
request.addProperty("usuario", usuario.getText().toString());
request.addProperty("contrasena",password.getText().toString());
```
Todo Web Service SOAP se encuentra en un "envelope" por lo cual tenemos que serializarlo. Lo conseguimos de la siguiente manera.
* La VER11 depende mucho de la versión de la libreria Ksoap2 que hayamos instalado, entre mayor la versión del Ksoap2, mayor la versión que recibe nuestro "envelope".
* Activamos el dot.
* Asignamos nuestro output de nuestro "envelope" al request que habíamos creado lineas arriba. 
* Finalmente creamos nuestro transporte, para saber de donde tiene que sacar este "envelope" y le pasamos nuestro URL.

```
SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
envelope.dotNet=true;

envelope.setOutputSoapObject(request);
HttpTransportSE transporte = new HttpTransportSE(URL);
```
Creamos nuestras condicionales:
* Si transporte funciona bien en su totalidad, guardamos el resultado en un SoapPrimitive, y finalmente al ser un resultado String, guardamos el mismo resultado en nuestra variable res, creada en la parte superior. 
* Creamos excepciones.
```
try
{
    transporte.call(SOAP_ACTION,envelope);
    SoapPrimitive resultado_xml = (SoapPrimitive) envelope.getResponse();
    res = resultado_xml.toString();
}catch(IOException e){
    e.printStackTrace();
}catch (XmlPullParserException e)
{
    e.printStackTrace();
}
```
Para que nuestra clase run se pueda iniciar, al estar todo dentro de un Thread necesitamos crear la siguiente clase: runOnUiThread(new Runneable())
* Dentro de esta clase asignaremos nuestro resultado a nuestro TextView. 
* Recordemos nuestro procedimiento .sql para el LOGIN

```
CREATE OR REPLACE PROCEDURE LOGIN(PV1 IN VARCHAR2, PV2 IN VARCHAR2, PS1 OUT NUMBER)AS
V_USUARIO NUMBER;
BEGIN
  SELECT ID INTO V_USUARIO FROM ADMINISTRADOR WHERE USUARIO = PV1 AND CONTRASEÑA = PV2;
  PS1 := V_USUARIO;

  EXCEPTION
  WHEN NO_DATA_FOUND THEN DBMS_OUTPUT.PUT_LINE('ERROR');
END;
```
* Como vemos en el procedimiento, nos retor el ID del administrador, y si no lo encuentra salta a la exepción, por lo cual sabemos que nos mandará "null".

* Al ser un login, creamos una condicional:
  - Si el resultado es igual a "null" nos manda un mensaje en el TextView que los datos son incorrectos.
  - Si devuelve algún resultado:
    - Intent es una función para poder pasar de una pantalla a otra en Android. 
    - En este caso nos deja pasar a la siguiente página que querramos ingresar una vez pasado el login.
* Finalmente no olvidemos iniciar nuestro hilo (Thread) con: nt.start()

```
runOnUiThread(new Runnable() {
    @Override
    public void run() {
        Toast.makeText(MainActivity.this,res,Toast.LENGTH_LONG).show();
        TextView result = (TextView) findViewById(R.id.textView3);


        if(res.equals("null"))
        {
            res = "DATOS INCORRECTOS";
            result.setText(res);

        }
        else
        {
            Intent siguiente = new Intent(MainActivity.this,MainPage.class);
            startActivity(siguiente);
        }

    }
});
nt.start();
```








