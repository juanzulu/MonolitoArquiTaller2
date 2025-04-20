-- Verificar y crear la base de datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GestionAcademica')
BEGIN
    CREATE DATABASE GestionAcademica;
    PRINT 'Base de datos GestionAcademica creada correctamente.';
END;

-- Cambiar al contexto de la base de datos
USE GestionAcademica;

-- Tabla Estudiante (creación condicional)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Estudiante' AND type = 'U')
BEGIN
    CREATE TABLE Estudiante (
        id_estudiante INT PRIMARY KEY IDENTITY(1,1),
        nombre NVARCHAR(100) NOT NULL,
        apellido NVARCHAR(100) NOT NULL,
        correo NVARCHAR(150) NOT NULL,
        documento NVARCHAR(50) NOT NULL
    );
    PRINT 'Tabla Estudiante creada correctamente.';
END;

-- Tabla Asignatura (creación condicional)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Asignatura' AND type = 'U')
BEGIN
    CREATE TABLE Asignatura (
        id_asignatura INT PRIMARY KEY IDENTITY(1,1),
        nombre NVARCHAR(100) NOT NULL,
        codigo NVARCHAR(50) NOT NULL,
        creditos INT NOT NULL
    );
    PRINT 'Tabla Asignatura creada correctamente.';
END;

-- Tabla Nota (creación condicional)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Nota' AND type = 'U')
BEGIN
    CREATE TABLE Nota (
        id_nota INT PRIMARY KEY IDENTITY(1,1),
        id_estudiante INT NOT NULL,
        id_asignatura INT NOT NULL,
        valor DECIMAL(3,2) NOT NULL CHECK (valor >= 0 AND valor <= 5),
        fecha_registro DATE NOT NULL,
        FOREIGN KEY (id_estudiante) REFERENCES Estudiante(id_estudiante),
        FOREIGN KEY (id_asignatura) REFERENCES Asignatura(id_asignatura)
    );
    PRINT 'Tabla Nota creada correctamente.';
END;
