# UsersMicroserviceAPI

UsersMicroserviceAPI es una API minimalista para gestionar perfiles de usuario, creada con ASP.NET Core. Esta API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre perfiles de usuario y está diseñada para ser modular y fácil de extender.

## Características

- API Minimalista sin controladores
- Operaciones CRUD para perfiles de usuario
- Integración con Entity Framework Core
- Ejemplo de arquitectura de microservicios

## Tecnologías

- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- Swagger para documentación de la API

## Requisitos Previos

- .NET 6.0 SDK o superior
- SQL Server
- Visual Studio o Visual Studio Code

## Configuración del Proyecto

Sigue estos pasos para configurar y ejecutar el proyecto en tu máquina local.

### 1. Clonar el Repositorio


git clone https://github.com/tu-usuario/UsersMicroserviceAPI.git
cd UsersMicroserviceAPI

##2. Configurar la Cadena de Conexión
Asegúrate de tener una base de datos SQL Server en funcionamiento. Luego, configura la cadena de conexión en appsettings.json.


{
  "ConnectionStrings": {
    "SqlConnection": "Server=tu_servidor;Database=UsersDB;User Id=tu_usuario;Password=tu_contraseña;"
  }
}
3. Ejecutar Migraciones
Ejecuta las migraciones para crear la base de datos y las tablas necesarias.

dotnet ef migrations add InitialMigration
dotnet ef database update

##4. Ejecutar la Aplicación
Inicia la aplicación.

dotnet run
La aplicación estará disponible en https://localhost:5001 y http://localhost:5000.

Endpoints de la API
La API proporciona los siguientes endpoints:

GET /users - Obtener todos los usuarios
GET /users/{id} - Obtener un usuario por ID
POST /users - Crear un nuevo usuario
PUT /users/{id} - Actualizar un usuario existente
DELETE /users/{id} - Eliminar un usuario

##Ejemplo de Peticiones

##Crear un Usuario

POST /users

Content-Type: application/json

{
  "userName": "johndoe",
  "email": "johndoe@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "dateOfBirth": "1990-01-01",
  "gender": "Male",
  "location": "New York",
  "bio": "Software Developer",
  "interests": ["Coding", "Hiking"],
  "photos": ["https://example.com/photo1.jpg"]
}

##Obtener Todos los Usuarios

GET /users
Obtener un Usuario por ID

GET /users/1
Actualizar un Usuario

PUT /users/1
Content-Type: application/json

{
  "userName": "johndoe",
  "email": "johndoe@example.com",
  "firstName": "John",
  "lastName": "Doe",
  "dateOfBirth": "1990-01-01",
  "gender": "Male",
  "location": "New York",
  "bio": "Senior Software Developer",
  "interests": ["Coding", "Hiking", "Reading"],
  "photos": ["https://example.com/photo1.jpg", "https://example.com/photo2.jpg"]
}

##Eliminar un Usuario

DELETE /users/1

##Documentación de la API
La documentación de la API está disponible en Swagger. Puedes acceder a ella visitando https://localhost:5001/swagger o http://localhost:5000/swagger una vez que la aplicación esté en funcionamiento.

##Contribuir
¡Las contribuciones son bienvenidas! Si deseas contribuir a este proyecto, por favor sigue los siguientes pasos:

##Haz un fork del proyecto.
Crea una rama para tu feature (git checkout -b feature/nueva-feature).
Haz commit de tus cambios (git commit -m 'Añadir nueva feature').
Sube tu rama (git push origin feature/nueva-feature).
Abre un Pull Request.

##Licencia
Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.

##Contacto
Si tienes alguna pregunta o sugerencia, no dudes en contactar a alexmateoweb3@gmail.com.

```bash
