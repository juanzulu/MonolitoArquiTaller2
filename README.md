
# 🎓 MonolitoTaller - Sistema de Gestión Académica

Este proyecto es un sistema **monolítico** desarrollado con **ASP.NET 8 MVC**, utilizando el patrón **DAO** para el acceso a datos y **SQL Server** como sistema de base de datos. Permite gestionar **estudiantes, asignaturas y notas** de forma sencilla, con una interfaz web limpia y pruebas de funcionalidad a través de **Postman**.

---

## 📦 Tecnologías utilizadas

- ✅ ASP.NET Core 8 MVC
- ✅ C#
- ✅ SQL Server 2022
- ✅ Patrón DAO
- ✅ Docker + Docker Compose
- ✅ Razor Views
- ✅ Postman (para pruebas)

---

## 📁 Estructura del Proyecto

```
monolitoTaller/
│
├── Controllers/           # Lógica de control MVC
├── Models/
│   ├── DAO/               # Clases DAO con operaciones SQL
│   └── Entities/          # Entidades del dominio
├── Views/                 # Vistas Razor por entidad
├── sql/                   # Script init.sql para creación de BD
├── Utils/                 # Clases auxiliares (opcional)
│
├── wwwroot/               # Archivos estáticos
├── appsettings.json       # Configuración del sistema
├── Dockerfile             # Imagen para la app
├── docker-compose.yml     # Infraestructura completa con BD
├── Program.cs             # Configuración del host y rutas
└── README.md              # Documentación del proyecto
```

---

## ⚙️ Stack Tecnológico

| Capa              | Tecnología             |
|-------------------|------------------------|
| Frontend/Backend  | ASP.NET 8 MVC          |
| Persistencia      | DAO (Data Access Object) |
| Base de Datos     | SQL Server             |
| Contenedores      | Docker + Docker Compose |
| Pruebas           | Postman                |

---

## 🚀 Despliegue con Docker

### 📌 Requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [SQL Server Management Studio (opcional)](https://aka.ms/ssmsfullsetup)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/es/) con soporte para .NET 8

### 🧪 Pasos para levantar el sistema

Puedes levantar el sistema de dos formas: clonando el repositorio o descargando el archivo comprimido desde Releases.

---

#### 🔁 Opción 1: Clonando desde GitHub

1. Abre una terminal (CMD o PowerShell)
2. Ejecuta los siguientes comandos:

```bash
git clone https://github.com/juanzulu/MonolitoArquiTaller2.git
cd MonolitoArquiTaller2
```

3. Asegúrate de que Docker Desktop esté abierto y ejecutándose.

4. Ejecuta los siguientes comandos:

```bash
docker compose up -d --build
Control + C                 # ← En caso de que docker compose se quede esperando
docker start monolito_app  # ← Obligatorio para iniciar IIS en el contenedor
```

5. Accede a la aplicación desde el navegador:
```
http://localhost:8080
```

---

#### 📦 Opción 2: Descargando desde Releases

1. Ve a la sección **Releases** del repositorio
2. Descarga el archivo ZIP de la versión más reciente
3. Descomprime la carpeta (ej: `MonolitoArquiTaller2-VersionFinal`)
4. Abre Docker Desktop y asegúrate de que esté ejecutándose
5. Abre una terminal dentro de la carpeta descomprimida y ejecuta:

```bash
docker compose up -d --build
Control + C                 # ← En caso de que docker compose se quede esperando
docker start monolito_app  # ← Obligatorio para iniciar IIS en el contenedor
```

6. Accede a la aplicación desde el navegador:
```
http://localhost:8080
```
---

## 🧪 Pruebas con Postman

Se han creado pruebas CRUD para todas las entidades.  
🔗 [Ir a la colección de Postman](https://www.postman.com/samuel-852536/workspace/monolito-taller2/collection/43512745-0f6a7606-71d6-4b2e-b3ee-71073a308abe?action=share&creator=43512745)

### 📦 Endpoints disponibles

| Entidad     | Método | Endpoint                  | Descripción                  |
|-------------|--------|---------------------------|------------------------------|
| Estudiante  | GET    | /Estudiante               | Lista estudiantes            |
| Estudiante  | POST   | /Estudiante/Create        | Crea estudiante              |
| Estudiante  | POST   | /Estudiante/Delete/{id}   | Elimina estudiante           |
| Asignatura  | GET    | /Asignatura               | Lista asignaturas            |
| Asignatura  | POST   | /Asignatura/Create        | Crea asignatura              |
| Asignatura  | POST   | /Asignatura/Delete/{id}   | Elimina asignatura           |
| Nota        | GET    | /Nota                     | Lista notas                  |
| Nota        | POST   | /Nota/Create              | Crea nota                    |
| Nota        | POST   | /Nota/Delete/{id}         | Elimina nota                 |

---

## 🧩 Scripts de Base de Datos

El archivo [`sql/init.sql`](./sql/init.sql) contiene:
- Creación de la base de datos `GestionAcademica`
- Creación de tablas `Estudiante`, `Asignatura`, `Nota`
- Relaciones entre claves foráneas

---


## 🛠️ Mantenimiento y Mejora

- Proyecto escalable con buena separación por capas.
- Preparado para agregar autenticación y validación futura.
- Dockeriza toda la solución para entornos homogéneos.

---

## © Créditos

Proyecto académico - Grupo 8  
Arquitectura de Software · Universidad Javeriana – 2025
