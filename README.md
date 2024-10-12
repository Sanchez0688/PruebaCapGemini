# PruebaCapGemini

## DATABASE

1- Ejecutar el archivo scriptDatabase.sql dentro de SQL Server

## API REST .NET CORE


2- Ir a la ruta ```\CoreProductosApi\col.Backend\appsettings.json``` y modificar el LocalConnection incluyendo los datos de la Base de datos Local
3- Ir a la ruta ```\CoreProductosApi\col.Test\ProductTest.cs``` y modificar nuevamente la coneccion a la Base de datos en la linea 31 
4- Ejecutar como proyecto de inicio el ```col.Backend``` se le abrira el navegador para pruebas por Swagger
8- Para poder ejecutar las pruebas se debe detener proyecto ```col.Backend``` y debes dirigirte al ```col.Test```

## API REST NODEJS 

5- Ejecuta comando ```nmp install```
6- Ir a la ruta "\node-productos-restapi\src\config.js" y cambiar los siguientes campos con los que le corresponden a su conexion 
```
DB_USER = youruser
DB_PASSWORD = yourpassword
DB_SERVER = localhost
DB_DATABASE = yourdatabase
DB_PORT = yourportDatabase
```
7- Ejecutar comando ```npm run dev```
8- Para poder ejecutar las pruebas se debe detener el npm y realizar ```npm test```
