# GestionBiblioteca10

Sistema de gestión bibliotecaria desarrollado en C# bajo el Framework .NET. Este proyecto implementa una solución robusta siguiendo las buenas prácticas de la ingeniería de software, utilizando una arquitectura multicapa para asegurar la escalabilidad y mantenibilidad del código.

## 📖 Descripción del Proyecto

El objetivo principal de esta aplicación es informatizar y facilitar los procesos diarios de una biblioteca, desde la gestión de inventario y usuarios hasta el control de préstamos y devoluciones.

El sistema se ha diseñado separando claramente las responsabilidades en capas:
* **Capa de Presentación:** Interfaz de usuario (Windows Forms) para la interacción con el sistema.
* **Capa de Lógica de Negocio:** Contiene las reglas y validaciones del sistema.
* **Capa de Persistencia:** Encargada de la comunicación con la base de datos y la transformación de datos.
* **Modelo de Dominio:** Definición de las entidades principales (Libros, Usuarios, Préstamos, etc.).

## 🚀 Características Principales

### Gestión de Catálogo y Ejemplares
* Alta, baja y modificación de documentos (Libros, AudioLibros, etc.).
* Gestión individual de ejemplares.
* Búsqueda avanzada de documentos y listados filtrados.

### Gestión de Usuarios
* Registro y administración de usuarios de la biblioteca.
* Búsqueda de usuarios por DNI.
* Historial de préstamos por usuario.

### Sistema de Préstamos
* **Alta de Préstamos:** Proceso para prestar ejemplares a usuarios registrados.
* **Devoluciones:** Gestión de la devolución de material.
* Consulta de estado de préstamos activos e históricos.

### Control de Acceso y Roles
* Sistema de **Login** para el personal.
* Roles diferenciados para la gestión:
    * **Personal de Adquisiciones:** Enfocado en la gestión del catálogo e inventario.
    * **Personal de Sala:** Enfocado en la atención al usuario y gestión de préstamos.

## 🛠️ Tecnologías Utilizadas

* **Lenguaje:** C#
* **Framework:** .NET Framework 4.7.2
* **Tipo de Aplicación:** Escritorio (Windows Forms)
* **Entorno de Desarrollo:** Visual Studio
* **Arquitectura:** N-Capas (Presentación, Negocio, Persistencia, Dominio)

## 📂 Estructura de la Solución

La solución está dividida en los siguientes proyectos:

1.  **Presentacion:** Formularios e interfaz gráfica (`FLogin`, `FAltaPrestamo`, `FListarEjemplares`, etc.).
2.  **LogicaNegocio:** Interfaces e implementaciones de la lógica (`LibroLN`, `PrestamoLN`, `UsuarioLN`).
3.  **Persistencia:** Acceso a datos y mapeo (`BD`, `Transformers`, `CRUD`).
4.  **ModeloDominio:** Clases base (`Libro`, `Usuario`, `Prestamo`, `Ejemplar`).

## 🔧 Instalación y Configuración

1.  Clonar el repositorio:
    ```bash
    git clone [https://github.com/tu-usuario/GestionBiblioteca10.git](https://github.com/tu-usuario/GestionBiblioteca10.git)
    ```
2.  Abrir el archivo `GestionBiblioteca10.sln` con Visual Studio.
3.  Restaurar los paquetes NuGet si es necesario.
4.  Verificar la cadena de conexión a la base de datos en los archivos de configuración o en la clase de persistencia (`BD.cs`).
5.  Compilar y ejecutar el proyecto seleccionando `Presentacion` como proyecto de inicio.

## ✒️ Autores

* **Equipo de Desarrollo** - *Alberto Hidalgo, Jon Jimenez, Isaac Terés*

---
