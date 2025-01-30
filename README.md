# dotnetSampleApi

## pasos para iniciar el api 

1. Crear la base de datos en postgreSQL

* ejecutta los siguientes comandos:
    ```cmd 
    dotnet tool install --global dotnet-ef --version 8.0.0
    ```

```
sudo su
psql
``` 
> [!IMPORTANT]
> Si tienes un error al ejecutar postgreSQL que menciona algo sobre permisos o puertos consulta el siguiente enlace para resolverlo
> https://stackoverflow.com/questions/32439167/psql-could-not-connect-to-server-connection-refused-error-when-connecting-to

* En postgres crea el usuario y base de datos "storeapi"
    ```sql
    CREATE USER storeapi WITH PASSWORD 'storeapi';
    CREATE DATABASE storeapi OWNER storeapi;
    ```
* Muevete a la carpeta del proyecto .NET
    ``` cmd
    cd storeAPIService
    ```
* Realiza el proceso de migración de la base de datos
    ``` cmd
    dotnet ef database update
    ```

2. Ejecutar el api
    
* En la ruta ```storeAPIService``` ejecuta el comando 
    ```
    dotnet watch run
    ```
>[!IMPORTANT]
>Se desplegará un pop up en la parte inferior derecha con el mensaje:
>La aplicación que se ejecuta en el puerto 5182 está disponible. [Ver todos los puertos reenviados] (command:~remote.forwardedPorts.focus)
> [Abrir en el navegador] [Hacer público]
>Debes dar click en hacer público

>[!NOTE]
>Si no lograste darle click o no te apareció el pop up en la cinta de terminal ve a la opción puertos
> busca el puerto 5182, da click derecho, selecciona visibilidad de puerto y selecciona público

* Ahora debes de abrir el enlace de la aplicacion anexando ```/swagger``` a la url por ejemplo:
https://psychic-zebra-r766r6v4g97257x4-5182.app.github.dev/swagger/index.html

>[!NOTE]
>Para ver la url hay que ir a la cinta de terminal en opción puertos
> busca el puerto 5182 y verás una url, esa es la URL de la aplicación
