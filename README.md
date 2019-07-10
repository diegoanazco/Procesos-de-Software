# Aplicación Android usando Web Service SOAP enlazado a una BD Oracle.

El siguiente proyecto tiene como fin crear una BD en Oracle 11g, vincularla a un Web Service y finalmente consumir el mismo desde una aplicación Android.

## Comenzando

Para el proyecto utilizamos una BD llamada Pedidos. Pedidos controla desde las ordenes de los clientes, hasta los proveedores que distribuyen los diferentes proyectos. De igual manera estaremos subiendo el script de la creación de la BD así como también como se pobló la data.

Para la realización del Web Service, usamos Visual Studio 2017, utilizando el lenguaje C#, llamando a distintos procedimientos creados en la BD. 

Finalmente, utilizamos Android Studio, para poder crear nuestra aplicación Android.

### Pre-requisitos 📋

* Oracle 11g. 
* Visual Studio 2017
  - Package Newtonsoft.Json: Al crear un Web Service SOAP vemos que nos retorna código .xml, si nosotros consideramos mejor manejable el formato JSON, tenemos esta referencia del Visual para poder retornar un string JSON.
    - https://www.c-sharpcorner.com/UploadFile/ansh06031982/creating-web-services-in-net-which-returns-xml-and-json-dat/
  - Conveyor by Keyoti para Visual Studio 2017: Sirve para crear el Web Service no solo en el localhost, si no también en la IP del router en el que te encuentras conectado. 
    - https://marketplace.visualstudio.com/items?itemName=vs-publisher-1448185.ConveyorbyKeyoti
* Android Studio 
  - Ksoap2 3.0.0: Libreria para poder consumir Web Service SOAP desde Android Studio
    - https://oss.sonatype.org/content/repositories/ksoap2-android-releases/com/google/code/ksoap2-android/ksoap2-android-assembly/

## Autores 

El proyecto se realizó como proyecto final del curso de Procesos de Software en la Universidad La Salle - Arequipa.

* **Diego Añazco** - *Alumno VI Ciclo, Universidad La Salle - Arequipa* - 
