# CVBuilder API
Asistente detallado para la creación de curriculum en línea de forma rápida y eficaz.

Backend creado usando ASP.NET Core Web API.

## Funcionalidades

* Creación de usuarios
* Completar secciones del curriculum de forma modular
* Posibilidad de crear secciones personalizadas
* Tres plantillas seleccionables de curriculum
* Generación de PDF
* Imprimir curriculum

## Tecnologías/librerías/plugins

* ASP.NET Core Web API
* Entity Framework Core / Migrations
* JwtBearer Authentication
* SQL Server
* Automapper

-------------

Para el frontend -> https://github.com/gustavo-vasquez/cvbuilder-project-ui

* HTML5
* CSS
* Bootstrap
* Javascript
* Ajax
* ReactJs
* Font Awesome
* dom-to-image
* jsPDF
* Formik
* Yup

-------------

PORTADA
:-------------------------:
![CVBuilder-Home](https://github.com/gustavo-vasquez/cvbuilder-project-ui/blob/master/public/assets/img/previews/1-inicio.png)

LOGIN Y REGISTRO
:-------------------------:
![CVBuilder-SignUp](https://github.com/gustavo-vasquez/cvbuilder-project-ui/blob/master/public/assets/img/previews/2-login_registro.jpg)

PESTAÑAS CON LAS SECCIONES DEL CURRICULUM
:-------------------------:
![CVBuilder-Tabs](https://github.com/gustavo-vasquez/cvbuilder-project-ui/blob/master/public/assets/img/previews/3-detalles_personales.jpg)

CAMBIO DE PLANTILLA
:-------------------------:
![CVBuilder-Tabs](https://github.com/gustavo-vasquez/cvbuilder-project-ui/blob/master/public/assets/img/previews/12-cambiar_plantilla.jpg)

IMPRIME O DESCARGA COMO PDF
:-------------------------:
![CVBuilder-Tabs](https://github.com/gustavo-vasquez/cvbuilder-project-ui/blob/master/public/assets/img/previews/16-cv_completado.jpg)

| ** PLANTILLAS DISPONIBLES ** |
:---------------------------------:

| Classic   |      Elegant      | Modern |
|----------|:-------------:|-------|
| ![CVBuilder-Tabs](https://github.com/gustavo-vasquez/cvbuilder-project-ui/blob/master/public/assets/img/previews/13-classic.jpg) |  ![CVBuilder-Tabs](https://github.com/gustavo-vasquez/cvbuilder-project-ui/blob/master/public/assets/img/previews/14-elegant.jpg) | ![CVBuilder-Tabs](https://github.com/gustavo-vasquez/cvbuilder-project-ui/blob/master/public/assets/img/previews/15-modern.jpg) |

## Notas
Cambiar la cadena de conexión en el archivo "appsettings.Development.json" por la propia y ejecutar el comando 'dotnet ef database update' para crear la base de datos.

## Autor
Gustavo Vasquez
