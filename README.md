# Laboratorio 04 · Recuperación de datos

Aplicación de escritorio WPF para el curso **Desarrollo de Aplicaciones Empresariales Avanzado**. El laboratorio utiliza ADO.NET en modo conectado con SQL Server y procedimientos almacenados sobre la base de datos `NeptunoDB`.

## Funcionalidades

- Mantenimiento de productos.
- Mantenimiento de categorías.
- Mantenimiento de proveedores.
- Búsqueda de proveedores por nombre de contacto y ciudad.
- Mantenimiento de pedidos.
- Reporte de detalle de pedidos dentro de un intervalo de fechas.

La interfaz presenta cada módulo en una navegación lateral. Cada pantalla incluye una tabla para consultar los registros y un formulario para crear o editar el registro seleccionado.

## Tecnologías

| Componente | Uso |
| --- | --- |
| .NET 10 para Windows | Plataforma de la aplicación |
| WPF | Interfaz de escritorio |
| ADO.NET | Acceso conectado a SQL Server |
| Microsoft.Data.SqlClient | Cliente de SQL Server |
| CommunityToolkit.Mvvm | ViewModels y comandos |
| SQL Server | Base de datos `NeptunoDB` |

## Estructura del proyecto

```text
DAEA_Lab04/
├── Database/
│   ├── NeptunoDB.sql             # Creación y datos de la base
│   └── StoredProcedures.sql      # Procedimientos almacenados
├── Lab04/
│   ├── Data/                     # Fábrica de conexiones
│   ├── Models/                   # Entidades del dominio
│   ├── Repositories/             # Acceso a datos mediante procedimientos
│   ├── ViewModels/               # Lógica de presentación y comandos
│   ├── MainWindow.xaml           # Interfaz principal
│   └── App.config                # Cadena de conexión
└── Lab04.slnx
```

## Requisitos

- Windows 10 u 11.
- Visual Studio para Windows con la carga de trabajo **Desarrollo de escritorio con .NET**.
- SQL Server o SQL Server Express.
- Una instancia de SQL Server disponible, por ejemplo `localhost`, `.\SQLEXPRESS` o `(localdb)\MSSQLLocalDB`.

> WPF solo se ejecuta en Windows. En macOS se pueden editar los archivos, pero para compilar, ejecutar y usar el diseñador se necesita Windows o una máquina virtual con Windows.

## Configuración

1. Abra `Lab04.slnx` con Visual Studio para Windows.
2. Abra SQL Server Management Studio, Azure Data Studio o una herramienta equivalente.
3. Ejecute `Database/NeptunoDB.sql` para crear la base de datos y sus datos iniciales.
4. Ejecute `Database/StoredProcedures.sql` para crear los procedimientos almacenados.
5. Revise la cadena de conexión en `Lab04/App.config`:

```xml
<add name="NeptunoDB"
     connectionString="Server=.\SQLEXPRESS;Database=NeptunoDB;Trusted_Connection=True;TrustServerCertificate=True;"
     providerName="Microsoft.Data.SqlClient" />
```

6. Ajuste `Server=` al nombre de la instancia local si es necesario.
7. Restaure los paquetes NuGet, compile la solución y ejecute con `F5`.

## Guía de uso

| Módulo | Uso |
| --- | --- |
| Productos | Pulse **Actualizar** para listar. Seleccione una fila para editarla o pulse **Nuevo producto** para registrar uno. |
| Categorías | Liste, seleccione o cree una categoría y guarde los cambios. |
| Proveedores | Complete nombre de contacto y/o ciudad, luego pulse **Buscar**. Use **Actualizar** para recuperar el listado completo. |
| Pedidos | Liste, seleccione o cree un pedido. El formulario permite registrar cliente, empleado, fechas y destino. |
| Reportes | Seleccione fecha inicial y final, luego pulse **Generar reporte** para ver el detalle de pedidos. |

Los botones **Guardar** y **Eliminar** usan los comandos ya definidos en los ViewModels. Para editar, primero seleccione un registro de la tabla. Para registrar, pulse el botón **Nuevo** del módulo correspondiente.

## Procedimientos almacenados

Los repositorios llaman procedimientos almacenados en vez de construir consultas SQL desde la interfaz. El archivo `StoredProcedures.sql` contiene los procedimientos CRUD para productos, categorías, proveedores y pedidos, además de los procedimientos para búsqueda de proveedores y reporte de detalles de pedido.

## Validación sugerida

Antes de entregar, compruebe lo siguiente en Visual Studio y SQL Server:

- La cadena de conexión abre `NeptunoDB` sin errores.
- Cada botón **Actualizar** recupera registros.
- Se puede insertar, modificar y eliminar un registro en cada mantenimiento.
- La búsqueda de proveedores acepta uno o ambos filtros.
- El reporte devuelve detalles al seleccionar un intervalo que contenga pedidos.

## Material del laboratorio

La práctica corresponde al tema de recuperación de datos con ADO.NET y procedimientos almacenados. Los archivos de apoyo recibidos para el laboratorio describen el uso de procedimientos almacenados, CRUD y reportes filtrados por fechas.
