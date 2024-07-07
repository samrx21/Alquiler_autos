USE master
GO

-- Crear la base de datos AlquilerVehiculos
CREATE DATABASE AlquilerVehiculos;
GO

-- Usar la base de datos AlquilerVehiculos
USE AlquilerVehiculos;
GO

-- Crear la tabla Clientes
CREATE TABLE Clientes (
    Cedula INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Apellido NVARCHAR(100),
    Direccion NVARCHAR(255),
    Telefono NVARCHAR(20),
    CorreoElectronico NVARCHAR(100)
);
GO

-- Crear la tabla CategoriasVehiculos
CREATE TABLE CategoriasVehiculos (
    CategoriaID INT PRIMARY KEY,
    NombreCategoria NVARCHAR(50),
    Descripcion NVARCHAR(255)
);

-- Crear la tabla Vehiculos
CREATE TABLE Vehiculos (
    Placa NVARCHAR(20) PRIMARY KEY,
    Marca NVARCHAR(50),
    Modelo NVARCHAR(50),
    Anio INT,
    TarifaPorDia MONEY,
	CategoriaID INT,
	FOREIGN KEY (CategoriaID) REFERENCES CategoriasVehiculos(CategoriaID)
);
GO

--Crear la tabla Seguros
CREATE TABLE Seguros (
    SeguroID INT PRIMARY KEY,
    NombreSeguro NVARCHAR(100),
    Cobertura NVARCHAR(255),
    PrecioAdicional MONEY
);
GO

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    EmpleadoID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Apellido NVARCHAR(100),
    Puesto NVARCHAR(50),
    Salario MONEY,
    FechaContratacion DATE
);
GO


-- Crear la tabla Sucursales
CREATE TABLE Sucursales (
    SucursalID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Direccion NVARCHAR(255),
    Telefono NVARCHAR(20),
);
GO

ALTER TABLE Empleados
ADD SucursalID INT
FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID);


-- Crear la tabla Mantenimiento
CREATE TABLE Mantenimiento (
    MantenimientoID INT IDENTITY(1,1) PRIMARY KEY,
    Placa NVARCHAR(20),
    FechaMantenimiento DATE,
    Descripcion NVARCHAR(255),
    Costo MONEY,
    FOREIGN KEY (Placa) REFERENCES Vehiculos(Placa)
);
GO

--Crear la tabla Ubicaciones disponibles
CREATE TABLE Ubicaciones (
    Ubicaciones INT IDENTITY(1,1) PRIMARY KEY,
    NombreUbicacion NVARCHAR(100),
    Direccion NVARCHAR(255)
);
GO

-- Crear la tabla Reservas
CREATE TABLE Reservas (
    ReservaID INT IDENTITY(1,1) PRIMARY KEY,
    ClienteID INT,
    PlacaVeh NVARCHAR(20),
	LugarEntrega_Devolucion INT,
	SeguroID INT,
    FechaReserva DATETIME,
    FechaInicio DATETIME,
    FechaFinalizacion DATETIME,
	CostoTotal MONEY,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(Cedula),
    FOREIGN KEY (PlacaVeh) REFERENCES Vehiculos(Placa) ON DELETE CASCADE,
	FOREIGN KEY (SeguroID) REFERENCES Seguros (SeguroID),
	FOREIGN KEY (LugarEntrega_Devolucion) REFERENCES Ubicaciones(Ubicaciones)
);
GO
--Crear la tabla Accesorios
CREATE TABLE Accesorios (
    AccesorioID INT PRIMARY KEY,
    NombreAccesorio NVARCHAR(100),
    PrecioAdicional MONEY
);
GO

--Crear la tabla Extras
CREATE TABLE Extras (
	ReservaID INT,
	AccesorioID INT,
	PRIMARY KEY(ReservaID,AccesorioID),
	FOREIGN KEY (ReservaID) REFERENCES Reservas(ReservaID) ON DELETE CASCADE,
    FOREIGN KEY (AccesorioID) REFERENCES Accesorios(AccesorioID) ON DELETE CASCADE
);
GO

-- Crear la tabla Incidencias
CREATE TABLE Incidencias (
    IncidenciaID INT IDENTITY(1,1) PRIMARY KEY,
    ReservaID INT,
    FechaIncidencia DATETIME,
    Descripcion NVARCHAR(255),
    FOREIGN KEY (ReservaID) REFERENCES Reservas(ReservaID) ON DELETE CASCADE
);
GO

-- Crear la tabla InventarioSucursal
CREATE TABLE InventarioSucursal (
    InventarioID INT PRIMARY KEY,
    SucursalID INT,
    VehiculoID NVARCHAR(20),
    FOREIGN KEY (SucursalID) REFERENCES Sucursales(SucursalID) ON DELETE CASCADE,
    FOREIGN KEY (VehiculoID) REFERENCES Vehiculos(Placa) ON DELETE CASCADE
);
GO

--Crear la tabla Clientes frecuentes
CREATE TABLE ClientesFrecuentes (
    ClienteFrecuenteID INT IDENTITY (1,1) PRIMARY KEY,
    Cedula INT,
    DescuentoAplicado DECIMAL(5, 2),
    FOREIGN KEY (Cedula) REFERENCES Clientes(Cedula) ON DELETE CASCADE
);
GO

-- Crear la tabla Devoluciones
CREATE TABLE Devoluciones (
    DevolucionID INT IDENTITY(1,1) PRIMARY KEY,
    ReservaID INT,
    FechaDevolucion DATETIME,
    Observaciones NVARCHAR(255),
    FOREIGN KEY (ReservaID) REFERENCES Reservas(ReservaID)
);
GO



--Datos semilla

-- Insertar 5 categor�as de veh�culos
INSERT INTO CategoriasVehiculos (CategoriaID, NombreCategoria, Descripcion)
VALUES
    (1, 'Econ�mico', 'Autom�viles peque�os y eficientes en t�rminos de consumo de combustible.'),
    (2, 'Sed�n', 'Autom�viles de tama�o mediano con cuatro puertas y espacio equilibrado.'),
    (3, 'SUV', 'Veh�culos utilitarios deportivos ideales para actividades al aire libre y viajes familiares.'),
    (4, 'Deportivo', 'Autom�viles deportivos con alto rendimiento y dise�o emocionante.'),
    (5, 'Lujo', 'Autom�viles de lujo de alta gama con caracter�sticas premium.');

-- Insertar 5 veh�culos
INSERT INTO Vehiculos (Placa, Marca, Modelo, Anio, TarifaPorDia, CategoriaID)
VALUES
    ('ABC123', 'Toyota', 'Corolla', 2022, 50.00, 1),
    ('XYZ789', 'Honda', 'Civic', 2023, 55.00, 1),
    ('DEF456', 'Ford', 'Fusion', 2022, 60.00, 2),
    ('GHI789', 'Chevrolet', 'Cruze', 2023, 55.00, 2),
    ('JKL321', 'Nissan', 'Altima', 2022, 55.00, 1);

-- Insertar 5 seguros
INSERT INTO Seguros 
VALUES
    (1,'Seguro B�sico', 'Cobertura b�sica', 10.00),
    (2,'Seguro Est�ndar', 'Cobertura est�ndar', 15.00),
    (3,'Seguro Premium', 'Cobertura premium', 20.00),
    (4,'Seguro de Responsabilidad', 'Cobertura de responsabilidad', 12.00),
    (5,'Seguro de Da�os', 'Cobertura contra da�os', 18.00);


-- Insertar 5 ubicaciones
INSERT INTO Ubicaciones (NombreUbicacion, Direccion)
VALUES
    ('Bogot�', 'Direcci�n de Bogot�'),
    ('Medell�n', 'Direcci�n de Medell�n'),
    ('Cali', 'Direcci�n de Cali'),
    ('Barranquilla', 'Direcci�n de Barranquilla'),
    ('Cartagena', 'Direcci�n de Cartagena');




INSERT INTO Sucursales (SucursalID, Nombre, Direccion, Telefono) VALUES 
(1, 'Sucursal A', 'Calle 123, Ciudad X', '123-456-7890'),
(2, 'Sucursal B', 'Avenida Principal, Ciudad Y', '987-654-3210'),
(3, 'Sucursal C', 'Calle Central, Ciudad Z', '555-123-4567'),
(4, 'Sucursal D', 'Avenida Norte, Ciudad W', '777-888-9999'),
(5, 'Sucursal E', 'Calle Sur, Ciudad V', '111-222-3333');


INSERT INTO Empleados (EmpleadoID, Nombre, Apellido, Puesto, Salario, FechaContratacion, SucursalID) VALUES 
(6, 'Juan', 'Garc�a', 'Gerente', 50000.00, '2020-03-15', 1),
(7, 'Mar�a', 'L�pez', 'Cajero', 30000.00, '2021-01-10', 1),
(3, 'Carlos', 'Mart�nez', 'Vendedor', 25000.00, '2021-05-20', 2),
(4, 'Ana', 'Rodr�guez', 'Asistente de Almac�n', 28000.00, '2020-11-28', 3),
(5, 'Pedro', 'Hern�ndez', 'Cajero', 32000.00, '2021-09-03', 2);
GO
INSERT INTO Mantenimiento (Placa, FechaMantenimiento, Descripcion, Costo) VALUES 
('ABC123', '2023-10-15', 'Cambio de aceite y filtro', 75.00),
('XYZ789', '2023-09-20', 'Revisi�n de frenos', 120.50),
('DEF456', '2023-08-05', 'Alineaci�n y balanceo', 90.00);
GO

INSERT INTO Accesorios (AccesorioID, NombreAccesorio, PrecioAdicional) VALUES
(1, 'Llantas de aleaci�n', 150.00),
(2, 'Techo solar', 300.00),
(3, 'Sistema de navegaci�n', 200.00),
(4, 'Asientos de cuero', 250.00),
(5, 'Sistema de audio premium', 180.00);
GO


	select * from Clientes 
	select * from Reservas 
	select * from Seguros
	select * from Ubicaciones
	select * from Reservas