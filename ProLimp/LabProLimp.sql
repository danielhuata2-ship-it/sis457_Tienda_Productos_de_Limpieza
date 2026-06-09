CREATE DATABASE LabProLimp;
USE master
GO

CREATE LOGIN usrprolimp WITH PASSWORD = '123456',
       CHECK_POLICY = OFF,
       CHECK_EXPIRATION = OFF,
       DEFAULT_DATABASE = LabProLimp
GO
USE LabProLimp
GO

CREATE USER usrprolimp FOR LOGIN usrprolimp
GO 
ALTER ROLE db_owner ADD MEMBER usrprolimp
GO


DROP TABLE IF EXISTS DetalleVenta;
DROP TABLE IF EXISTS Venta;
DROP TABLE IF EXISTS Producto;
DROP TABLE IF EXISTS Empleado;
DROP TABLE IF EXISTS Proveedor;
DROP TABLE IF EXISTS Cliente;
DROP TABLE IF EXISTS Marca;
DROP TABLE IF EXISTS Categoria;
DROP TABLE IF EXISTS UnidadMedida;


CREATE TABLE UnidadMedida(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	descripcion VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE Categoria(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Marca(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Cliente(
	id INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	razon_social VARCHAR (50) NULL,
	cedula_identidad VARCHAR (10) NULL,
);

CREATE TABLE Proveedor(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	nombre_empresa VARCHAR (50) NOT NULL,
	telefono BIGINT NOT NULL,
	direccion VARCHAR (250) NULL,
	email VARCHAR (100) NOT NULL
);

 CREATE TABLE Empleado(
	id INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
	nombres VARCHAR(30) NOT NULL,
	primer_apellido VARCHAR(30) NOT NULL,
	segundo_apellido VARCHAR (30) NULL,
	cedula_identidad VARCHAR (10) NOT NULL,
	usuario VARCHAR(50) NOT NULL UNIQUE,
	clave VARCHAR (200) NOT NULL,
	telefono BIGINT NOT NULL
 );

 CREATE TABLE Producto(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	id_unidad_medida INT NOT NULL,
	id_proveedor INT NOT NULL,
	id_categoria INT NULL,
	id_marca INT NULL,
	codigo VARCHAR (20) NOT NULL,
	nombre VARCHAR (100)  NOT NULL,
	precio_unitario DECIMAL NOT NULL CHECK (precio_unitario>0),
	stock INT NOT NULL,
	fecha_vencimiento DATE NULL,
	precio_compra DECIMAL NOT NULL CHECK (precio_compra >= 0),
	cantidad_minima_stock INT NOT NULL DEFAULT 5,
	CONSTRAINT fk_Producto_UnidadMedida FOREIGN KEY (id_unidad_medida) REFERENCES UnidadMedida(id),
	CONSTRAINT fk_Producto_Proveedor FOREIGN KEY (id_proveedor) REFERENCES Proveedor(id),
	CONSTRAINT fk_Producto_Categoria FOREIGN KEY (id_categoria) REFERENCES Categoria(id),
	CONSTRAINT fk_Producto_Marca FOREIGN KEY (id_marca) REFERENCES Marca(id)
);

CREATE TABLE Venta(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	id_cliente INT NOT NULL,
	id_empleado INT NOT NULL,
	fecha DATE NOT NULL DEFAULT GETDATE(),
	total DECIMAL NOT NULL CHECK (total>0),
	CONSTRAINT fk_Venta_Cliente FOREIGN KEY (id_cliente) REFERENCES Cliente(id),
	CONSTRAINT fk_Venta_Empleado FOREIGN KEY (id_empleado) REFERENCES Empleado(id)
);

CREATE TABLE DetalleVenta(
	id INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	id_venta INT NOT NULL,
	id_producto INT NOT NULL,
	cantidad DECIMAL NOT NULL,
	precio_unitario DECIMAL NOT NULL CHECK (precio_unitario>0),
	subtotal DECIMAL NOT NULL,
	CONSTRAINT fk_DetalleVenta_Venta FOREIGN KEY (id_venta) REFERENCES Venta(id),
	CONSTRAINT fk_DetalleVenta_Producto FOREIGN KEY (id_producto) REFERENCES Producto(id)
);

ALTER TABLE UnidadMedida ADD usuario_registro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE UnidadMedida ADD fecha_registro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE UnidadMedida ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Categoria ADD usuario_registro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Categoria ADD fecha_registro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Categoria ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Marca ADD usuario_registro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Marca ADD fecha_registro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Marca ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Cliente ADD usuario_registro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Cliente ADD fecha_registro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Cliente ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Proveedor ADD usuario_registro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Proveedor ADD fecha_registro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Proveedor ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Empleado ADD usuario_registro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Empleado ADD fecha_registro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Empleado ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Producto ADD usuario_registro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Producto ADD fecha_registro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Producto ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE Venta ADD usuario_registro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE Venta ADD fecha_registro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE Venta ADD estado SMALLINT NOT NULL DEFAULT 1;

ALTER TABLE DetalleVenta ADD usuario_registro VARCHAR(50) NOT NULL DEFAULT SUSER_NAME();
ALTER TABLE DetalleVenta ADD fecha_registro DATETIME NOT NULL DEFAULT GETDATE();
ALTER TABLE DetalleVenta ADD estado SMALLINT NOT NULL DEFAULT 1;


GO
DROP PROC IF EXISTS paUnidadMedidaListar;
GO
CREATE PROC paUnidadMedidaListar @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        um.id, um.descripcion, um.usuario_registro, um.fecha_registro, um.estado
    FROM UnidadMedida um
    WHERE um.estado > -1
      AND um.descripcion LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY um.estado DESC, um.descripcion ASC;
END;
GO

EXEC paUnidadMedidaListar '';

GO
DROP PROC IF EXISTS paCategoriaListar;
GO
CREATE PROC paCategoriaListar @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        c.id, c.nombre, c.usuario_registro, c.fecha_registro, c.estado
    FROM Categoria c
    WHERE c.estado > -1
      AND c.nombre LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY c.estado DESC, c.nombre ASC;
END;
GO

EXEC paCategoriaListar '';

GO
DROP PROC IF EXISTS paMarcaListar;
GO
CREATE PROC paMarcaListar @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        m.id, m.nombre, m.usuario_registro, m.fecha_registro, m.estado
    FROM Marca m
    WHERE m.estado > -1
      AND m.nombre LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY m.estado DESC, m.nombre ASC;
END;
GO

EXEC paMarcaListar '';

GO
DROP PROC IF EXISTS paClienteListar;
GO
CREATE PROC paClienteListar @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        c.id,
        c.razon_social,
        c.cedula_identidad,
        c.usuario_registro,
        c.fecha_registro,
        c.estado
    FROM Cliente c
    WHERE c.estado > -1
      AND (
            ISNULL(c.razon_social, '') + ' ' +
            ISNULL(c.cedula_identidad, '')
          ) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY c.estado DESC, c.razon_social ASC;
END;
GO

EXEC paClienteListar '';

GO
DROP PROC IF EXISTS paProveedorListar;
GO
CREATE PROC paProveedorListar @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        pr.id,
        pr.nombre_empresa,
        pr.telefono,
        pr.direccion,
        pr.email,
        pr.usuario_registro,
        pr.fecha_registro,
        pr.estado
    FROM Proveedor pr
    WHERE pr.estado > -1
      AND (
            pr.nombre_empresa +
            pr.email +
            ISNULL(pr.direccion, '')
          ) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY pr.estado DESC, pr.nombre_empresa ASC;
END;
GO

EXEC paProveedorListar '';

GO
DROP PROC IF EXISTS paEmpleadoListar;
GO
CREATE PROC paEmpleadoListar @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        e.id,
        e.nombres,
        e.primer_apellido,
        e.segundo_apellido,
        e.usuario,
        e.telefono,
        e.usuario_registro,
        e.fecha_registro,
        e.estado
    FROM Empleado e
    WHERE e.estado > -1
      AND (
            e.nombres +
            ISNULL(e.primer_apellido, '') +
            ISNULL(e.segundo_apellido, '') +
            e.usuario +
            ISNULL(e.cedula_identidad, '')
          ) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY e.estado DESC, e.nombres ASC;
END;
GO

EXEC paEmpleadoListar '';

GO
DROP PROC IF EXISTS paProductoListar;
GO
CREATE PROC paProductoListar @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        p.id,
        p.id_unidad_medida,
        p.id_proveedor,
        p.id_marca,
        p.id_categoria,
        p.codigo,
        p.nombre,
        ISNULL(c.nombre, '') AS categoria,
        um.descripcion AS unidad_medida,
        ISNULL(m.nombre, '') AS marca,
        p.stock,
        p.precio_unitario AS precio_venta,
        p.fecha_vencimiento,
        p.precio_compra,
        p.cantidad_minima_stock,
        pr.nombre_empresa AS proveedor,
        p.usuario_registro,
        p.fecha_registro,
        p.estado
    FROM Producto p
    INNER JOIN UnidadMedida um ON um.id = p.id_unidad_medida
    INNER JOIN Proveedor pr ON pr.id = p.id_proveedor
    LEFT JOIN Categoria c ON c.id = p.id_categoria
    LEFT JOIN Marca m ON m.id = p.id_marca
    WHERE p.estado > -1
      AND (
            ISNULL(p.codigo,'') + ' ' +
            ISNULL(p.nombre,'') + ' ' +
            ISNULL(c.nombre,'') + ' ' +
            ISNULL(um.descripcion,'') + ' ' +
            ISNULL(pr.nombre_empresa,'') + ' ' +
            ISNULL(m.nombre,'')
          ) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY p.estado DESC, p.nombre ASC;
END;
GO

EXEC paProductoListar '';

GO
DROP PROC IF EXISTS paVentaListar;
GO
CREATE PROC paVentaListar @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        v.id,
        v.id_cliente,
        v.id_empleado,
        v.fecha,
        v.total,
        v.usuario_registro,
        v.fecha_registro,
        v.estado
    FROM Venta v
    WHERE v.estado > -1
      AND CAST(v.fecha AS VARCHAR) + CAST(v.total AS VARCHAR)
          LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY v.estado DESC, v.fecha DESC;
END;
GO

EXEC paVentaListar '';

GO
DROP PROC IF EXISTS paDetalleVentaListar;
GO
CREATE PROC paDetalleVentaListar @parametro VARCHAR(50)
AS
BEGIN
    SELECT
        dv.id,
        dv.id_venta,
        dv.id_producto,
        dv.cantidad,
        dv.precio_unitario,
        dv.subtotal,
        dv.usuario_registro,
        dv.fecha_registro,
        dv.estado
    FROM DetalleVenta dv
    WHERE dv.estado > -1
      AND (
            CAST(dv.cantidad AS VARCHAR) +
            CAST(dv.precio_unitario AS VARCHAR) +
            CAST(dv.subtotal AS VARCHAR)
          ) LIKE '%' + REPLACE(@parametro, ' ', '%') + '%'
    ORDER BY dv.estado DESC, dv.id ASC;
END;
GO

EXEC paDetalleVentaListar '';

INSERT INTO Marca(nombre)
VALUES ('Ola'), ('Omo'), ('Surf'), ('Skip'), ('Liz'), ('Dove'), ('Rexona'), ('Axe'), ('Sedal'), ('Pedsodent'), ('Colgate'), ('Adayo'), ('Muvel')

SELECT * FROM Marca;

INSERT INTO Categoria(nombre)
VALUES
('Limpieza de baño'),
('Limpieza capilar'),
('Limpieza dental'),
('Papel higiénico y servilletas'),
('Limpieza de cocina'),
('Detergentes y lavado de ropa'),
('Jabón de manos y cuerpo'),
('Desodorantes y cuidado personal'),
('Desinfectantes y antibacteriales'),
('Productos para pisos'),
('Aromatizantes y ambientadores')

SELECT * FROM Categoria;

INSERT INTO Proveedor(nombre_empresa,telefono,direccion,email)
VALUES ('Distribuidora Limpieza Total SRL', '76451234', 'Av. Blanco Galindo', 'contacto@limpiezatotal.com')

SELECT * FROM Proveedor;

INSERT INTO UnidadMedida(descripcion)
VALUES ('Litro'),('Kilo'),('Gramo'),('Mililitro'),('Paquete'),('Caja')

SELECT * FROM UnidadMedida

INSERT INTO Producto(id_unidad_medida,id_proveedor,id_marca,id_categoria,codigo,nombre,precio_unitario,stock,fecha_vencimiento,precio_compra,cantidad_minima_stock)
VALUES ('6','1','1','1','PROD001','Limpia Baños','25.50','100','2026-05-10','15.00','10')

DELETE FROM Empleado
WHERE usuario = 'dhuata'

INSERT INTO Empleado(nombres,primer_apellido,segundo_apellido,cedula_identidad,usuario,clave,telefono)
VALUES ('Daniel','Huata','Florse','13464570','dhuata','i0hcoO/nssY6WOs9pOp5Xw==','67625178')

INSERT INTO Empleado(nombres,primerApellido,segundoApellido,cedulaIdentidad,usuario,clave,telefono)
VALUES ('Erika','Mendoza','Daza','10390430','edaza','oUOsoOGI3rrEsSxCa0AXBW9n4JFJdDR6uJN1ggL4NkM=','67649000')

SELECT * FROM Empleado

INSERT INTO Cliente(razon_social,cedula_identidad)
VALUES ('Consumidor Final','0')

SELECT * FROM Cliente
