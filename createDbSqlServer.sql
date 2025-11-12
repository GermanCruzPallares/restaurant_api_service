CREATE DATABASE RestauranteDB;

SELECT name, database_id, create_date 
FROM sys.databases 
WHERE name = 'RestauranteDB';

USE RestauranteDB;
<<<<<<< HEAD
CREATE TABLE MenuDelDia (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE NOT NULL UNIQUE,
    PlatoPrincipalId INT NOT NULL,
    BebidaId INT NOT NULL,
    PostreId INT NOT NULL,
    PrecioTotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (PlatoPrincipalId) REFERENCES PlatoPrincipal(Id),
    FOREIGN KEY (BebidaId) REFERENCES Bebida(Id),
    FOREIGN KEY (PostreId) REFERENCES Postre(Id)
);
=======
>>>>>>> master

CREATE TABLE PlatoPrincipal (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL CHECK (Precio >= 0),
    Ingredientes NVARCHAR(MAX) NOT NULL
);

CREATE TABLE Postre (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL CHECK (Precio >= 0),
    Calorias INT NOT NULL
);

CREATE TABLE Bebida (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL CHECK (Precio >= 0),
    EsAlcoholica BIT
);

CREATE TABLE Combo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PlatoPrincipal INT NOT NULL,
    Bebida INT NOT NULL,
    Postre INT NOT NULL,
    Descuento DECIMAL(10, 2) NOT NULL CHECK (Descuento >= 0)
);
<<<<<<< HEAD
=======
CREATE TABLE MenuDelDia (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATE NOT NULL,
    PlatoPrincipalId INT NOT NULL,
    BebidaId INT NOT NULL,
    PostreId INT NOT NULL,
    PrecioTotal FLOAT NOT NULL,

    CONSTRAINT FK_MenuDelDia_PlatoPrincipal FOREIGN KEY (PlatoPrincipalId) REFERENCES PlatoPrincipal(Id),
    CONSTRAINT FK_MenuDelDia_Bebida FOREIGN KEY (BebidaId) REFERENCES Bebida(Id),
    CONSTRAINT FK_MenuDelDia_Postre FOREIGN KEY (PostreId) REFERENCES Postre(Id)
);
>>>>>>> master

INSERT INTO PlatoPrincipal (Nombre, Precio, Ingredientes)
VALUES 
('Plato combinado', 12.50, 'Pollo, patatas, tomate'),
('Plato vegetariano', 10.00, 'Tofu, verduras, arroz');

INSERT INTO Postre (Nombre, Precio, Calorias)
VALUES 
('Postre dulce', 5.00, 300),
('Postre dulzón', 8.00, 600);

INSERT INTO Bebida (Nombre, Precio, EsAlcoholica)
VALUES 
('Bebida mojada', 4.40, 1),
('Bebida húmeda', 5.70, 0);

INSERT INTO Combo (PlatoPrincipal, Bebida, Postre, Descuento)
VALUES 
(1, 1, 2, 0.20);

SELECT * FROM PlatoPrincipal;

SELECT * 
FROM PlatoPrincipal
WHERE Ingredientes LIKE '%Tofu%';

SELECT * 
FROM PlatoPrincipal
ORDER BY Precio ASC;

<<<<<<< HEAD
SELECT DISTINCT Nombre, Precio FROM PlatoPrincipal;
=======
SELECT DISTINCT Nombre, Precio FROM PlatoPrincipal;


#Setup local db (Sql server)
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU21-ubuntu-20.04
>>>>>>> master
