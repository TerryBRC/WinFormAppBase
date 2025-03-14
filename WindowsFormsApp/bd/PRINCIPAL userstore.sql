
CREATE TABLE `ubicacion` (
  `IdUbicacion` int NOT NULL AUTO_INCREMENT,
  `Ubicacion` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`IdUbicacion`)
);

CREATE TABLE `producto` (
  `IdProducto` int NOT NULL AUTO_INCREMENT,
  `Producto` varchar(100) DEFAULT NULL,
  `Precio` decimal(10,2) DEFAULT NULL,
  `Stock` int DEFAULT NULL,
  PRIMARY KEY (`IdProducto`)
);


CREATE TABLE `usuario` (
  `IdUsuario` int NOT NULL AUTO_INCREMENT,
  `Nombre_Completo` varchar(100) DEFAULT NULL,
  `usuario` varchar(50) DEFAULT NULL,
  `pwd` varchar(255) DEFAULT NULL,
  `IdUbicacion` int DEFAULT NULL,
  `Rol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IdUsuario`),
  UNIQUE KEY `usuario_UNIQUE` (`usuario`),
  KEY `fk_usuario_ubicacion` (`IdUbicacion`),
  CONSTRAINT `fk_usuario_ubicacion` FOREIGN KEY (`IdUbicacion`) REFERENCES `ubicacion` (`IdUbicacion`)
);



CREATE TABLE `empleado` (
  `IdEmpleado` int NOT NULL AUTO_INCREMENT,
  `Nombre_Completo` varchar(100) DEFAULT NULL,
  `Fecha_Ingreso` date DEFAULT NULL,
  `IdUsuario` int DEFAULT NULL,
  PRIMARY KEY (`IdEmpleado`),
  KEY `fk_empleado_usuario_idx` (`IdUsuario`),
  CONSTRAINT `fk_empleado_usuario` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`IdUsuario`)
);


CREATE TABLE `venta` (
  `IdVenta` int NOT NULL AUTO_INCREMENT,
  `IdUsuario` int DEFAULT NULL,
  `No_Factura` varchar(45) DEFAULT NULL,
  `No_SAP` varchar(50) DEFAULT NULL,
  `MontoTotal` decimal(9,2) DEFAULT NULL,
  `FechaRegistro` datetime,
  PRIMARY KEY (`IdVenta`),
  KEY `fk_venta_usuario` (`IdUsuario`),
  CONSTRAINT `fk_venta_usuario` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`IdUsuario`)
);


CREATE TABLE `detalle_venta` (
  `IdDetalleVenta` int NOT NULL AUTO_INCREMENT,
  `IdVenta` int DEFAULT NULL,
  `IdProducto` int DEFAULT NULL,
  `PrecioVenta` decimal(10,2) DEFAULT NULL,
  `Cantidad` int DEFAULT NULL,
  `SubTotal` decimal(9,2) DEFAULT NULL,
  PRIMARY KEY (`IdDetalleVenta`),
  KEY `fk_detalle_venta_producto` (`IdProducto`),
  KEY `fk_detalle_venta_venta` (`IdVenta`),
  CONSTRAINT `fk_detalle_venta_producto` FOREIGN KEY (`IdProducto`) REFERENCES `producto` (`IdProducto`),
  CONSTRAINT `fk_detalle_venta_venta` FOREIGN KEY (`IdVenta`) REFERENCES `venta` (`IdVenta`) ON DELETE CASCADE
);


INSERT INTO `detalle_venta` VALUES (1,1,1,17500.00,1,17500.00),(2,2,5,34.00,60,2040.00),(3,3,6,20000.00,1,20000.00),(4,4,2,1300.00,1,1300.00),(5,5,6,20000.00,1,20000.00),(6,5,1,17500.00,1,17500.00),(7,5,3,15000.00,1,15000.00);

DELIMITER ;;
CREATE TRIGGER `actualizar_stock_despues_venta` AFTER INSERT ON `detalle_venta` FOR EACH ROW BEGIN
    UPDATE Producto
    SET Stock = Stock - NEW.Cantidad
    WHERE IdProducto = NEW.IdProducto;
END ;;
DELIMITER ;




INSERT INTO `empleado` VALUES (1,'Vendedor de Prueba','2025-03-08',5),(2,'Paola Medina H','2025-01-14',7),(3,'Ester Martinez R','2025-02-03',8),(6,'Xiomara Chevez','2025-03-10',11);




INSERT INTO `producto` VALUES (1,'Telefono Samsung A15',17500.00,23),(2,'Cocina Electrica',1300.00,9),(3,'Sofa 3 pzs',15000.00,3),(4,'prueba',12.00,23),(5,'prueba2',34.00,5),(6,'telefono',20000.00,0);

--
-- Table structure for table `ubicacion`
--



INSERT INTO `ubicacion` VALUES (1,'PLANTA 1'),(2,'PLANTA 2'),(3,'PLANTA 3'),(4,'PLANTA 4'),(5,'PLANTA 5'),(6,'PLANTA 6'),(7,'EHPOSADA'),(8,'DIVINA');




--
-- Dumping data for table `usuario`
--

INSERT INTO `usuario` VALUES (5,'Vendedor de Prueba','vendedorprueba','$2a$11$whjA69K6IDgVHKbE2sdp3uTYq5qqUSmMlcLGjl3LhUOnAXHkhIUI.',2,'Vendedor'),(7,'Paola Medina','pmedinam','$2a$11$bBaeckPkt68HfOyk7DHSeew7y8e3JluxM1jeB4oH/r3drTrFJZik2',8,'Vendedor'),(8,'Ester Martinez','emartinez','$2a$11$TsaXU0lLsfsWbvuz81w1Ne5NWsTsZdsSMKhLSD2LYdl4qr9wat7Qm',7,'Administrador'),(10,'Terry B. Ramírez','admin','$2a$11$VTj.W5vlZohiK9K7RlWVq.cSMfFyznFL4qZ1xxi/VelJr84viMzDW',8,'Administrador'),(11,'Xiomara Chevez','xchevez','$2a$11$oNHijaZg0seQV4HKFISHN.q5y75jh8qGa0qNc5/jeg76.O3V5vz6a',7,'Vendedor');

-- Table structure for table `venta`
--



INSERT INTO `venta` VALUES (1,5,'3333','7897841',17500.00,'2025-03-09 00:07:12'),(2,5,'A001','C/F',2040.00,'2025-03-10 13:25:34'),(3,11,'001','terry',20000.00,'2025-03-10 15:16:38'),(4,10,'34543','C/F',1300.00,'2025-03-11 23:11:45'),(5,10,'2123','C/F',52500.00,'2025-03-11 23:13:19');

--
-- Dumping routines for database 'bdstore'
--
DROP PROCEDURE IF EXISTS `BuscarVentaDetallePorNoSAP`;
DELIMITER ;;
CREATE PROCEDURE `BuscarVentaDetallePorNoSAP`(IN p_NO_SAP VARCHAR(50))
BEGIN
    SELECT 
        v.IdVenta,
        v.IdUsuario,
        v.No_Factura,
        v.No_SAP,
        v.MontoTotal,
        v.FechaRegistro,
        dv.IdDetalleVenta,
        dv.IdProducto,
        p.Producto,
        dv.PrecioVenta,
        dv.Cantidad,
        dv.SubTotal
    FROM 
        venta v
    LEFT JOIN 
        detalle_venta dv ON v.IdVenta = dv.IdVenta
	left join 
        producto p on dv.IdProducto=p.IdProducto
    WHERE 
        v.No_SAP LIKE CONCAT('%', p_NO_SAP, '%');
END ;;
DELIMITER ;

DROP PROCEDURE IF EXISTS `DeleteDetalleVenta`;
DELIMITER ;;
CREATE PROCEDURE `DeleteDetalleVenta`(
    IN p_IdDetalleVenta INT
)
BEGIN
    DELETE FROM detalle_venta WHERE IdDetalleVenta = p_IdDetalleVenta;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `DeleteEmpleado`;
DELIMITER ;;
CREATE PROCEDURE `DeleteEmpleado`(
    IN p_IdEmpleado INT
)
BEGIN
    DELETE FROM empleado WHERE IdEmpleado = p_IdEmpleado;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `DeleteProducto`;
DELIMITER ;;
CREATE PROCEDURE `DeleteProducto`(
    IN p_IdProducto INT
)
BEGIN
    DELETE FROM producto WHERE IdProducto = p_IdProducto;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `DeleteUbicacion` ;
DELIMITER ;;
CREATE PROCEDURE `DeleteUbicacion`(IN p_IdUbicacion INT)
BEGIN
    DELETE FROM ubicacion WHERE IdUbicacion = p_IdUbicacion;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `DeleteUsuario`;
DELIMITER ;;
CREATE PROCEDURE `DeleteUsuario`(IN p_IdUsuario INT)
BEGIN
    DELETE FROM usuario WHERE IdUsuario = p_IdUsuario;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `DeleteVenta`;
DELIMITER ;;
CREATE PROCEDURE `DeleteVenta`(
    IN p_IdVenta INT
)
BEGIN
    DELETE FROM venta WHERE IdVenta = p_IdVenta;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetDetallesByVentaId`;
DELIMITER ;;
CREATE PROCEDURE `GetDetallesByVentaId`(
    IN p_IdVenta INT
)
BEGIN
    SELECT * FROM detalle_venta WHERE IdVenta = p_IdVenta;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetDetallesVenta`;
DELIMITER ;;
CREATE PROCEDURE `GetDetallesVenta`()
BEGIN
    SELECT * FROM detalle_venta;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetDetalleVentaById`;
DELIMITER ;;
CREATE PROCEDURE `GetDetalleVentaById`(
    IN p_IdDetalleVenta INT
)
BEGIN
    SELECT * FROM detalle_venta WHERE IdDetalleVenta = p_IdDetalleVenta;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetEmpleadoById`;
DELIMITER ;;
CREATE PROCEDURE `GetEmpleadoById`(
    IN p_IdEmpleado INT
)
BEGIN
    SELECT * FROM empleado WHERE IdEmpleado = p_IdEmpleado;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetEmpleados`;
DELIMITER ;;
CREATE PROCEDURE `GetEmpleados`()
BEGIN
    SELECT emp.IdEmpleado as Id,
    emp.Nombre_Completo as 'Nombre Completo',
    emp.Fecha_Ingreso as Ingreso,
    us.IdUsuario,
    us.usuario as Usuario,
    us.IdUbicacion,
    us.Rol as Rol
    FROM empleado emp join usuario us on emp.IdUsuario=us.IdUsuario;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetProductoById`;
DELIMITER ;;
CREATE PROCEDURE `GetProductoById`(
    IN p_IdProducto INT
)
BEGIN
    SELECT * FROM producto WHERE IdProducto = p_IdProducto;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetProductos`;
DELIMITER ;;
CREATE PROCEDURE `GetProductos`()
BEGIN
    SELECT * FROM producto order by producto Asc;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetUbicaciones`;
DELIMITER ;;
CREATE PROCEDURE `GetUbicaciones`()
BEGIN
    SELECT * FROM ubicacion;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetUsuarioById`;
DELIMITER ;;
CREATE PROCEDURE `GetUsuarioById`(IN p_IdUsuario INT)
BEGIN
    SELECT * FROM usuario WHERE IdUsuario = p_IdUsuario;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetUsuarioPorNombreUsuario`;
DELIMITER ;;
CREATE PROCEDURE `GetUsuarioPorNombreUsuario`(
    IN p_usuario VARCHAR(50)
)
BEGIN
    SELECT 
        IdUsuario,
        Nombre_Completo,
        usuario,
        pwd,
        IdUbicacion,
        Rol
    FROM usuario
    WHERE usuario = p_usuario;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetUsuarios`;
DELIMITER ;;
CREATE PROCEDURE `GetUsuarios`()
BEGIN
    SELECT * FROM usuario;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetVentaById`;
DELIMITER ;;
CREATE PROCEDURE `GetVentaById`(
    IN p_IdVenta INT
)
BEGIN
    SELECT * FROM venta WHERE IdVenta = p_IdVenta;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `GetVentas`;
DELIMITER ;;
CREATE PROCEDURE `GetVentas`()
BEGIN
    SELECT * FROM venta;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `InsertDetalleVenta`;
DELIMITER ;;
CREATE PROCEDURE `InsertDetalleVenta`(
    IN p_IdVenta INT,
    IN p_IdProducto INT,
    IN p_PrecioVenta DECIMAL(10,2),
    IN p_Cantidad INT,
    IN p_SubTotal DECIMAL(9,2)
)
BEGIN
    INSERT INTO detalle_venta (IdVenta, IdProducto, PrecioVenta, Cantidad, SubTotal)
    VALUES (p_IdVenta, p_IdProducto, p_PrecioVenta, p_Cantidad, p_SubTotal);
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `InsertEmpleado`;
DELIMITER ;;
CREATE PROCEDURE `InsertEmpleado`(
    IN p_NombreCompleto VARCHAR(100),
    IN p_FechaIngreso DATE,
    IN p_IdUsuario INT,
    OUT p_IdEmpleado INT
)
BEGIN
    INSERT INTO empleado (Nombre_Completo, Fecha_Ingreso, IdUsuario)
    VALUES (p_NombreCompleto, p_FechaIngreso, p_IdUsuario);
    -- Obtener el ID generado
    SET p_IdEmpleado = LAST_INSERT_ID();
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `InsertProducto`;
DELIMITER ;;
CREATE PROCEDURE `InsertProducto`(
    IN p_Producto VARCHAR(100),
    IN p_Precio DECIMAL(10,2),
    IN p_Stock INT
)
BEGIN
    INSERT INTO producto (Producto, Precio, Stock)
    VALUES (p_Producto, p_Precio, p_Stock);
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `InsertUbicacion`;
DELIMITER ;;
CREATE PROCEDURE `InsertUbicacion`(IN p_UbicacionN VARCHAR(25))
BEGIN
    INSERT INTO ubicacion (Ubicacion) VALUES (p_UbicacionN);
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `InsertUsuario`;
DELIMITER ;;
CREATE PROCEDURE `InsertUsuario`(
    IN p_Nombre_Completo VARCHAR(100),
    IN p_usuario VARCHAR(50),
    IN p_pwd VARCHAR(255),
    IN p_IdUbicacion INT,
    IN p_Rol VARCHAR(45),
    OUT p_IdUsuario INT
)
BEGIN
    INSERT INTO usuario (Nombre_Completo, usuario, pwd, IdUbicacion, Rol)
    VALUES (p_Nombre_Completo, p_usuario, p_pwd, p_IdUbicacion, p_Rol);

    -- Obtener el ID generado
    SET p_IdUsuario = LAST_INSERT_ID();
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `InsertVenta`;
DELIMITER ;;
CREATE PROCEDURE `InsertVenta`(
    IN p_IdUsuario INT,
    IN p_NoFactura VARCHAR(45),
    IN p_NoSAP VARCHAR(50),
    IN p_MontoTotal DECIMAL(9,2),
    IN p_FechaRegistro DATETIME
)
BEGIN
    INSERT INTO venta (IdUsuario, No_Factura, No_SAP, MontoTotal, FechaRegistro)
    VALUES (p_IdUsuario, p_NoFactura, p_NoSAP, p_MontoTotal, p_FechaRegistro);
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `ObtenerStockBajo`;
DELIMITER ;;
CREATE PROCEDURE `ObtenerStockBajo`()
BEGIN
    
    SELECT 
        IdProducto,
        Producto,
        Stock
    FROM producto
    WHERE Stock < 5
    ORDER BY Stock ASC;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `ObtenerVentasPorRangoFechas`;
DELIMITER ;;
CREATE PROCEDURE `ObtenerVentasPorRangoFechas`(IN p_FechaInicio DATE, IN p_FechaFin DATE)
BEGIN
    
    SELECT 
        v.IdVenta,
        v.IdUsuario,
        v.No_Factura,
        v.No_SAP,
        v.MontoTotal,
        v.FechaRegistro
    FROM venta v
    WHERE DATE(v.FechaRegistro) BETWEEN p_FechaInicio AND p_FechaFin
    ORDER BY v.FechaRegistro ASC;
    
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `UpdateDetalleVenta`;
DELIMITER ;;
CREATE PROCEDURE `UpdateDetalleVenta`(
    IN p_IdDetalleVenta INT,
    IN p_IdVenta INT,
    IN p_IdProducto INT,
    IN p_PrecioVenta DECIMAL(10,2),
    IN p_Cantidad INT,
    IN p_SubTotal DECIMAL(9,2)
)
BEGIN
    UPDATE detalle_venta 
    SET IdVenta = p_IdVenta,
        IdProducto = p_IdProducto,
        PrecioVenta = p_PrecioVenta,
        Cantidad = p_Cantidad,
        SubTotal = p_SubTotal
    WHERE IdDetalleVenta = p_IdDetalleVenta;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `UpdateEmpleado`;
DELIMITER ;;
CREATE PROCEDURE `UpdateEmpleado`(
    IN p_IdEmpleado INT,
    IN p_NombreCompleto VARCHAR(100),
    IN p_FechaIngreso DATE,
    IN p_IdUsuario INT
)
BEGIN
    UPDATE empleado 
    SET Nombre_Completo = p_NombreCompleto,
        Fecha_Ingreso = p_FechaIngreso,
        IdUsuario = p_IdUsuario
    WHERE IdEmpleado = p_IdEmpleado;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `UpdateProducto`;
DELIMITER ;;
CREATE PROCEDURE `UpdateProducto`(
    IN p_IdProducto INT,
    IN p_Producto VARCHAR(100),
    IN p_Precio DECIMAL(10,2),
    IN p_Stock INT
)
BEGIN
    UPDATE producto 
    SET Producto = p_Producto,
        Precio = p_Precio,
        Stock = p_Stock
    WHERE IdProducto = p_IdProducto;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `UpdateUbicacion`;
DELIMITER ;;
CREATE PROCEDURE `UpdateUbicacion`(IN p_IdUbicacion INT, IN p_UbicacionN VARCHAR(25))
BEGIN
    UPDATE ubicacion SET Ubicacion = p_UbicacionN WHERE IdUbicacion = p_IdUbicacion;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `UpdateUsuario`;
DELIMITER ;;
CREATE PROCEDURE `UpdateUsuario`(
    IN p_IdUsuario INT,
    IN p_Nombre_Completo VARCHAR(100),
    IN p_usuario VARCHAR(50),
    IN p_pwd VARCHAR(255),
    IN p_IdUbicacion INT,
    IN p_Rol VARCHAR(45)
)
BEGIN
    UPDATE usuario 
    SET 
        Nombre_Completo = p_Nombre_Completo,
        usuario = p_usuario,
        pwd = p_pwd,
        IdUbicacion = p_IdUbicacion,
        Rol = p_Rol
    WHERE IdUsuario = p_IdUsuario;
END ;;
DELIMITER ;
DROP PROCEDURE IF EXISTS `UpdateVenta`;
DELIMITER ;;
CREATE PROCEDURE `UpdateVenta`(
    IN p_IdVenta INT,
    IN p_IdUsuario INT,
    IN p_NoFactura VARCHAR(45),
    IN p_NoSAP VARCHAR(50),
    IN p_MontoTotal DECIMAL(9,2),
    IN p_FechaRegistro DATETIME
)
BEGIN
    UPDATE venta 
    SET IdUsuario = p_IdUsuario,
        No_Factura = p_NoFactura,
        No_SAP = p_NoSAP,
        MontoTotal = p_MontoTotal,
        FechaRegistro = p_FechaRegistro
    WHERE IdVenta = p_IdVenta;
END ;;
DELIMITER ;


-- Dump completed on 2025-03-13  2:44:30
