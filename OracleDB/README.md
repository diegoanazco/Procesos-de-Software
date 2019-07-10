# Oracle 11g : Creación, población, y procedimientos en la BD.

Los siguientes archivos tienen como fin explicar la creación, población y procedimientos de la BD que utilizaremos para que nuestro Web Service lo pueda consumir.

## Comenzando 

En un primer lugar mostraremos el diagrama ER para poder facilitar la comprensión de lo que trata nuestra BD. Basicamente trata sobre una empresa que se dedica a vender productos a diferentes clientes, cuenta con sus empleados, así como su cabecera de ordenes. De igual forma cuenta con sus proveedores, que son aquellos que nos abastecen de los productos.

### ¿Qué se encuentra en esta carpeta? 📋
* BD_DiagramaER
  - Muestra el Diagrama ER de la BD, con la finalidad de una mejor comprensión de la misma. Viendo sus relaciones y sus diferentes PK y FK.
  - Como vemos existe una tabla "Administrador" que se encuentra aislada, esta tabla se hizo con el fin de registrar a todos aquellos que pueden entrar desde el "Login" de nuestra aplicación.
* BD_Script_Creacion
  - Es el DDL del diagrama ER anterior, donde puedes utilizarlo si es que deseas tener la misma base de datos. 
* BD_Script_PoblacionData
  - Todos los datos insertados a la BD para poder poblarla de manera optima y razonable.
* BD_Script_Procedimientos
  - Contiene los siguientes procedimientos:
    - Procedimiento de LOGIN.
    - Procedimientos SIDU (Select, Insert, Delete, Update) de la tabla Administrador.
    - Procedimientos SIDU de la tabla Clientes.
 
