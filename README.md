# Prueba Back End #2 - Double V Partners

Bienvenidos a este repositorio. Aquí encontrarás la Prueba Back End #2 para la empresa Double V Partners. En esta prueba, se te solicita realizar una API con un CRUD de Tickets. La recuperación de tickets debe incluir paginación y permitir filtrado por todos los tickets o por uno específico.

## Tecnologías Utilizadas

- *Base de Datos*: SQL Server
- *C# .NET CORE 8 con Microsoft Visual Studio 2022

## Instrucciones de Configuración

1. *Crear Base de Datos*:
   - Crear una base de datos local llamada doublevpartnersdb.

2. *Configuración del Proyecto*:
   - Ajustar la instancia de la base de datos en el archivo appsettings.json. En la sección "DefaultConnection", especificar la instancia del servidor y el nombre de la base de datos.

3. *Migraciones*:
   - Navegar al proyecto Persistence.Database.
   - Ejecutar los siguientes comandos para aplicar las migraciones:
     sh
     dotnet ef migrations add nombre_migracion
     dotnet ef database update
     

4. *Ejecutar la API*:
   - Iniciar la API.
   - Se cargará Swagger automáticamente para realizar pruebas de la API.

## Uso de la API

Una vez ejecutada la API, puedes utilizar Swagger para interactuar con los endpoints y realizar operaciones CRUD sobre los tickets. Swagger proporciona una interfaz gráfica amigable para probar las funcionalidades de la API de manera rápida y sencilla.
