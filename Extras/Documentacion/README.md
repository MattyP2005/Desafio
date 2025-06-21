#  Informe Técnico - Sistema de Gestión de Flotas y Mantenimiento Predictivo

##  Autor

**Nombre:** Matías Pérez  
**Carrera:** Ingeniería de Software  
**Universidad:** Universidad Técnica del Norte  
**Año:** 2025
**Materia** Herramientas de Programacion

##  Descripción General

Este proyecto implementa un sistema distribuido que permite gestionar flotas de camiones y predecir mantenimientos futuros mediante sensores simulados. 
Se desarrolló una solución con arquitectura modular, múltiples motores de base de datos, y componentes orientados a servicios (API RESTful). 
El sistema incluye exportaciones, alertas, pruebas unitarias, y una interfaz web amigable para usuarios técnicos y operativos.

##  Estructura del Proyecto

La solución completa se divide en 5 proyectos principales, organizados por responsabilidades:

- **Libreria.API**  
  Proyecto de tipo API RESTful que expone endpoints para gestionar todas las entidades del sistema. Usa Entity Framework Core y soporta SQL Server + MariaDB.

- **Libreria.Modelos**  
  Contiene las clases de dominio (entidades) que representan la lógica de negocio. Se comparte entre los demás proyectos.

- **Libreria.MVC**  
  Aplicación web ASP.NET Core MVC con vistas Razor para que el usuario interactúe con el sistema (CRUD, dashboard, exportaciones, etc.).

- **Libreria.API.Consumer**  
  Contiene servicios que consumen la API usando `HttpClient`. Permite desacoplar la lógica de acceso a datos en la aplicación MVC.

- **Libreria.Test**  
  Proyecto de pruebas unitarias usando xUnit. Valida el comportamiento de entidades clave como Mantenimiento, SensorLog y AlertaMantenimiento.

##  Entidades del sistema

El sistema está construido sobre 6 entidades principales, cada una representando un componente clave de la gestión de flotas:

- **Camion**  
  Representa un vehículo registrado en la flota. Contiene datos como modelo, año y una relación con su conductor asignado.

- **Conductor**  
  Contiene la información de los choferes responsables de operar los camiones. Incluye nombre y número de licencia.

- **Taller**  
  Centros de servicio donde se realizan mantenimientos. Tienen nombre, ciudad y capacidad máxima.

- **Mantenimiento**  
  Registra servicios realizados a camiones, vinculando el vehículo con un taller y una fecha. Puede ser preventivo o correctivo.

- **SensorLog**  
  Simula los datos reportados por sensores (kilometraje, estado del motor, fecha/hora). Es generado automáticamente por el simulador.

- **AlertaMantenimiento**  
  Representa una alerta predictiva generada por el sistema cuando un camión supera un umbral crítico. Puede marcarse como crítica o informativa.

##  Funcionalidades desarrolladas

El sistema cumple con todos los requisitos funcionales planteados en el desafío. Las principales funcionalidades desarrolladas son:

- **CRUD completo para todas las entidades**  
  Operaciones de crear, leer, actualizar y eliminar para Camión, Conductor, Taller, Mantenimiento, SensorLog y Alerta, tanto en la API como en la aplicación MVC.

- **Relaciones maestro-detalle**  
  Asociación de mantenimientos con camiones y talleres, y de camiones con conductores.

- **API RESTful documentada**  
  Endpoints desarrollados siguiendo buenas prácticas REST, con pruebas desde Swagger.

- **Soporte para múltiples motores de base de datos**  
  La API trabaja con SQL Server para la mayoría de datos y MariaDB para alertas de mantenimiento.

- **Servicio de mantenimiento predictivo**  
  Un servicio en segundo plano analiza las lecturas de sensores y genera alertas automáticamente.

- **Simulador de sensores**  
  Proyecto de consola que envía lecturas falsas de kilometraje y estado del motor cada 5 segundos.

- **Visualización en tiempo real (AJAX)**  
  Dashboard que actualiza la tabla de alertas sin recargar la página, usando jQuery y AJAX.

- **Exportación de alertas a Excel**  
  Las alertas pueden descargarse como archivo `.xlsx` usando la librería ClosedXML.

- **Separación por capas y principios SOLID**  
  Uso de interfaces, inyección de dependencias, y separación entre lógica de negocio, datos y presentación.

##  Pruebas Unitarias

Se implementaron pruebas básicas usando el framework **xUnit** en el proyecto `Libreria.Test`. Estas pruebas verifican la lógica interna de las entidades más importantes:

- `MantenimientoTests`: verifica que se pueda crear un mantenimiento válido con camión, taller y fecha.
- `SensorLogTests`: asegura que los valores generados por el simulador estén dentro de los rangos esperados.
- `AlertaTests`: comprueba que una alerta crítica sea detectada correctamente.

###  Ejecución de pruebas

Podemos ejecutar las pruebas desde la terminal con:

```bash
dotnet test Libreria.Test
```

##  Evidencias

A continuación se listan los recursos generados como respaldo visual del funcionamiento del sistema:

-  **Diagrama de clases UML**  
  Representa las entidades y sus relaciones. Fue generado usando Graphviz y PlantUML.

-  **Esquema de base de datos (BDD)**  
  Incluye un archivo `.sql` con la estructura de tablas y una imagen del modelo relacional (PK/FK).

-  **Capturas de pruebas unitarias**  
  Evidencia de pruebas ejecutadas con éxito mediante `dotnet test`.

-  **Dashboard en tiempo real**  
  Interfaz web que muestra las alertas generadas sin recargar la página.

-  **Exportación de alertas a Excel**  
  Funcionalidad implementada con ClosedXML, genera un archivo `.xlsx` con todas las alertas.

> Todos estos archivos están organizados en la carpeta `/Documentacion` del proyecto.

## Requisitos Técnicos

Este sistema fue desarrollado usando las siguientes herramientas, frameworks y tecnologías:

- **.NET 8**  
  Plataforma base para los proyectos API, MVC, Test y Consola.

- **Visual Studio 2022 / VS Code**  
  IDEs utilizados para desarrollar, depurar y gestionar la solución.

- **Entity Framework Core 8**  
  ORM utilizado para la persistencia de datos y soporte a múltiples motores (SQL Server y MariaDB).

- **SQL Server 2022**  
  Motor principal para almacenar camiones, mantenimientos, conductores, etc.

- **MariaDB / HeidiSQL**  
  Usado como segunda base de datos para almacenar las alertas predictivas generadas automáticamente.

- **ClosedXML**  
  Librería para generar archivos Excel (`.xlsx`) desde el frontend MVC.

- **xUnit**  
  Framework de pruebas unitarias para validar la lógica del sistema.

- **jQuery + AJAX**  
  Para actualizar en tiempo real el dashboard de alertas sin recargar la página.

- **Python + Graphviz (opcional)**  
  Utilizado para generar el diagrama visual del esquema de base de datos.

## Estado del Proyecto

A continuación se resumen los principales componentes solicitados en el desafío y su estado de implementación:

| Requisito                          | Estado |
|-----------------------------------|--------|
| CRUD API + MVC                    | ✅     |
| EF Core con 2 motores de BD       | ✅     |
| Servicio de mantenimiento predictivo | ✅  |
| Simulador de sensores             | ✅     |
| Exportar alertas a Excel          | ✅     |
| Dashboard en tiempo real (AJAX)  | ✅     |
| Diagrama de clases + esquema BDD | ✅     |
| Pruebas unitarias (xUnit)         | ✅     |
| Informe técnico (README.md)       | ✅     |