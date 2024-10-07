# ClinicaSepriceAPI

## Este proyecto es una ASP.NET Core Web API desarrollada con .NET 8.0, que incluye un proyecto para pruebas unitarias con NUnit.

**Descripción del Proyecto**

El proyecto está implementado en .NET 8.0 y utiliza Entity Framework Core 8.0.8 para la comunicación con la base de datos MySql. También está configurado para usar autenticación JWT y soporte de Swagger para documentación de la API.

**Paquetes NuGet necesarios**
Para ejecutar y desarrollar el proyecto principal y el proyecto de pruebas, asegúrate de tener instalados los siguientes paquetes:

**Microsoft.AspNet.WebApi.Core (5.3.0)**: Proporciona soporte de API Web en ASP.NET.

**Microsoft.AspNetCore.Authentication.JwtBearer (8.0.8)**: Para la autenticación basada en JWT.

**Microsoft.EntityFrameworkCore (8.0.8)**: ORM para interactuar con bases de datos relacionales.

**Microsoft.EntityFrameworkCore.Design (8.0.8)**: Herramientas de diseño necesarias para las migraciones de Entity Framework.

**Microsoft.EntityFrameworkCore.Tools (8.0.8)**: Herramientas de línea de comandos para EF Core.

**Pomelo.EntityFrameworkCore.MySql (8.0.2)**: Proveedor de Entity Framework Core para bases de datos MySQL.

**Microsoft.EntityFrameworkCore.InMemory (8.0.8)**: Proveedor en memoria para pruebas con bases de datos simuladas (usado en el proyecto de pruebas).

**Moq (4.20.72)**: Biblioteca para crear objetos simulados (mocks) en pruebas.

# Estructura de Carpetas

La organización del proyecto sigue una estructura modular para facilitar el desarrollo y mantenimiento. A continuación, se describe la función de cada carpeta:

```bash
ClinicaSepriceAPI/
├──Common/
├── Controllers/
├── Data/
├── DTOs/
├── Exceptions/
├── Filters/
├── Helpers/
├── Interfaces/
├── Migrations/
├── Models/
├── Repositories/
├── Services/
├── appsettings.json
└── Program.cs
```
Breve descripcion de que contiene cada carpeta. 

**Common/:** Actualmente contiene constantes  para ser utilizadas en los DTOs  

**Controllers/:** Define los controladores de la API, que manejan las rutas y definen los endpoints (GET, POST, PUT, DELETE, etc.). Cada controlador hereda de ControllerBase.

**Data/:** Incluye archivos relacionados con el acceso a la base de datos, como el contexto de Entity Framework (DbContext). También puede contener migraciones y configuraciones adicionales de la base de datos.

**DTOs/:** Contiene los Data Transfer Objects, clases que definen cómo se transfieren los datos entre el cliente y el servidor. Estos objetos permiten transferir solo la información necesaria, ocultando la estructura interna de las entidades.

**Exceptions/:** Aquí se encuentran las excepciones personalizadas utilizadas en el proyecto, como UsuarioNoExisteException o AutenticacionFallidaException, para un manejo de errores más específico.

**Filters/:** Contiene filtros personalizados aplicables a las acciones de los controladores. Estos filtros pueden incluir lógica de autorización, manejo de excepciones, validación, entre otros.

**Helpers/:** Clases auxiliares que contienen funciones reutilizables y métodos utilitarios. Incluye, por ejemplo, el PasswordHelper para el manejo de hash y verificación de contraseñas.

**Interfaces/:** Define las interfaces que representan contratos para servicios y repositorios, lo cual facilita la inyección de dependencias y la separación de responsabilidades.

**Migrations/:** Carpeta generada por Entity Framework que contiene las migraciones para gestionar cambios en la base de datos.

**Models/:** Define las clases de modelo que representan las entidades y objetos de dominio. Estas clases se mapean a las tablas de la base de datos al usar Entity Framework.

**Repositories/:** Implementa el patrón de repositorio para encapsular la lógica de acceso a datos. Facilita la interacción con la base de datos y permite un acceso más limpio y fácil de probar.

**Services/:** Contiene la lógica de negocio de la aplicación. Los servicios son invocados desde los controladores y generalmente interactúan con los repositorios o modelos de datos.

**Properties/:** Incluye archivos de propiedades, como el de configuración de ensamblado AssemblyInfo.cs.

**appsettings.json:** Archivo de configuración que incluye parámetros de la base de datos, JWT y otras configuraciones de la aplicación.

**Program.cs:** Configura los servicios y el middleware necesarios para que la API funcione correctamente.