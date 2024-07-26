-- Crear tabla de Universidades
CREATE TABLE Universidades (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Decano VARCHAR(100) NOT NULL
);

ALTER TABLE Universidades
CHANGE COLUMN Nombre Nombres VARCHAR(100) NOT NULL;


-- Crear tabla de Carreras
CREATE TABLE Carreras (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);


-- Crear tabla de Materias
CREATE TABLE Materias (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Carrera_Id INT,
    FOREIGN KEY (Carrera_Id) REFERENCES Carreras(Id)
);


-- Crear tabla de Semestres
CREATE TABLE Semestres (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Numero TINYINT NOT NULL CHECK (Numero BETWEEN 1 AND 2),
    Año YEAR NOT NULL
);

-- Crear tabla de Profesores
CREATE TABLE Profesores (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) UNIQUE NOT NULL,
    Telefono VARCHAR(20) NOT NULL
);

-- Crear tabla de Estados
CREATE TABLE Estados (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre_Estado VARCHAR(100) NOT NULL,
    Tipo_Estado ENUM('Inscripcion', 'Estudiante') NOT NULL
);

ALTER TABLE Estados
CHANGE COLUMN Estado Nombre_Estado VARCHAR(100) NOT NULL;


-- Crear tabla de Carrera_Materia con clave compuesta
CREATE TABLE Carrera_Materia (
    Carrera_Id INT NOT NULL,
    Materia_Id INT NOT NULL,
    PRIMARY KEY (Carrera_Id, Materia_Id),
    FOREIGN KEY (Carrera_Id) REFERENCES Carreras(Id),
    FOREIGN KEY (Materia_Id) REFERENCES Materias(Id)
);

-- Crear tabla de Profesor_Materia con clave compuesta
CREATE TABLE Profesor_Materia (
    Profesor_Id INT NOT NULL,
    Materia_Id INT NOT NULL,
    PRIMARY KEY (Profesor_Id, Materia_Id),
    FOREIGN KEY (Profesor_Id) REFERENCES Profesores(Id),
    FOREIGN KEY (Materia_Id) REFERENCES Materias(Id)
);

-- Crear tabla de Carrera_Universidad con clave compuesta
CREATE TABLE Carrera_Universidad (
    Carrera_Id INT NOT NULL,
    Universidad_Id INT NOT NULL,
    PRIMARY KEY (Carrera_Id, Universidad_Id),
    FOREIGN KEY (Carrera_Id) REFERENCES Carreras(Id),
    FOREIGN KEY (Universidad_Id) REFERENCES Universidades(Id)
);


-- Crear tabla de Estudiantes
CREATE TABLE Estudiantes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombres VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) UNIQUE NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Universidad_Id INT,
    Estado_Id INT,
    FOREIGN KEY (Universidad_Id) REFERENCES Universidades(Id),
    FOREIGN KEY (Estado_Id) REFERENCES Estados(Id)
);

-- Crear tabla de Profesor_Universidad con clave compuesta
CREATE TABLE Profesor_Universidad (
    Profesor_Id INT NOT NULL,
    Universidad_Id INT NOT NULL,
    PRIMARY KEY (Profesor_Id, Universidad_Id),
    FOREIGN KEY (Profesor_Id) REFERENCES Profesores(Id),
    FOREIGN KEY (Universidad_Id) REFERENCES Universidades(Id)
);

-- Crear tabla de Estudiantes_Materia con clave compuesta
CREATE TABLE Estudiantes_Materia (
    Estudiante_Id INT NOT NULL,
    Materia_Id INT NOT NULL,
    PRIMARY KEY (Estudiante_Id, Materia_Id),
    FOREIGN KEY (Estudiante_Id) REFERENCES Estudiantes(Id),
    FOREIGN KEY (Materia_Id) REFERENCES Materias(Id)
);

-- Crear tabla de Inscripciones
CREATE TABLE Inscripciones (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Estudiante_Id INT NOT NULL,
    Carrera_Id INT NOT NULL,
    Profesor_Id INT NOT NULL,
    Semestre_Id INT NOT NULL,
    Fecha_Inscripcion DATE NOT NULL,
    Estado_Id INT NOT NULL,
    FOREIGN KEY (Estudiante_Id) REFERENCES Estudiantes(Id),
    FOREIGN KEY (Carrera_Id) REFERENCES Carreras(Id),
    FOREIGN KEY (Profesor_Id) REFERENCES Profesores(Id),
    FOREIGN KEY (Semestre_Id) REFERENCES Semestres(Id),
    FOREIGN KEY (Estado_Id) REFERENCES Estados(Id)
);

-- Crear tabla de Universidad_Inscripcion con clave compuesta
CREATE TABLE Universidad_Inscripcion (
    Universidad_Id INT NOT NULL,
    Inscripcion_Id INT NOT NULL,
    PRIMARY KEY (Universidad_Id, Inscripcion_Id),
    FOREIGN KEY (Universidad_Id) REFERENCES Universidades(Id),
    FOREIGN KEY (Inscripcion_Id) REFERENCES Inscripciones(Id)
);


