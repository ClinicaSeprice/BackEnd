El proyecto es un ASP.NET Core Web API  con .NET 8.0 y ademas un proyecto para Unit Test  Nunit

El proyecto esta hecho con .NET 8.0 y para la comunicación  con la base de datos utilizaremos Entity Framework  Core 8.0.8  y la Base de datos a utilizar sera SQL SERVER

Los paquetes NuGet necesarios seran los siguientes: 

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

La estructura de carpetas adicionales creadas para el son las siguientes. 

```bash
ClinicaSepriceAPI/
├── Controllers/
├── Data/
├── DTOs/
├── Execeptions/
├── Filters/
├── Helpers/
├── Models/
├── Migrations/
├── Repositories/
├── Services/
```
Breve descripcion de que contiene cada carpeta. 

Controllers/: En esta carpeta se ubican los controladores de la API. Cada controlador gestiona rutas específicas y define los puntos finales (endpoints) que recibirán solicitudes HTTP (GET, POST, PUT, DELETE, etc.). Cada controlador hereda de ControllerBase.

Data/: Aquí se incluyen los archivos relacionados con el acceso a la base de datos, como el contexto de Entity Framework (DbContext). También puede incluir migraciones y configuraciones de la base de datos.

DTOs/: Contiene los Data Transfer Objects (DTOs), que son clases que definen cómo los datos se transfieren entre el cliente y el servidor. Los DTOs permiten enviar o recibir solo los datos necesarios, protegiendo la estructura interna de las entidades.

Filters/: Contiene filtros personalizados que se aplican a las acciones del controlador. Estos pueden ser filtros de acción, de autorización, de excepción, etc., que te permiten aplicar lógica antes o después de que se ejecuten las acciones.

Helpers/: En esta carpeta se ubican clases auxiliares que contienen funciones reutilizables, métodos estáticos y utilidades que no encajan en las demás capas pero que son necesarias para la lógica del negocio o manejo de errores.

Models/: Aquí se definen las clases de modelo que representan las entidades y objetos de dominio de la clínica. Estas clases mapean a las tablas de la base de datos si estás usando Entity Framework.

Repositories/: Esta carpeta contiene las clases de repositorio que gestionan el acceso a los datos. El patrón Repositorio se utiliza para encapsular la lógica de acceso a datos, permitiendo un acceso más limpio a la base de datos y facilitando la prueba unitaria.

Services/: Aquí se colocan los servicios que contienen la lógica de negocio de la aplicación. Estos servicios son invocados desde los controladores y suelen interactuar con los repositorios o modelos de datos.


