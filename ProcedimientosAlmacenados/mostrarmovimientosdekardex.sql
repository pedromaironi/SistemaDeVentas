Create proc MOSTRAR_MOVIMIENTOS_DE_KARDEX

@idProducto int
AS
Select KARDEX.Fecha, Producto1.Descripcion, KARDEX.Motivo AS Movimiento, KARDEX.Cantidad, KARDEX.Tipo, KARDEX.Cantidad, KARDEX.Hay as Hay, USUARIO2.Nombre_y_Apellido as Cajero ,Grupo_de_Productos.Linea as Categoria, KARDEX.Costo_unt, KARDEX.Total
,Grupo_de_Productos.linea, EMPRESA.Nombre_Empresa,EMPRESA.Logo, Producto1.Stock,Convert(numeric(18,2),Producto1.Stock * KARDEX.Costo_unt) as TotalInventario
From dbo.KARDEX INNER JOIN Producto1 on Producto1.Id_Producto1 = KARDEX.Id_producto INNER JOIN USUARIO2 on USUARIO2.idUsuario = KARDEX.Id_usuario
	cross join EMPRESA
	inner join Grupo_de_Productos on Grupo_de_Productos.Idline=Producto1.Id_grupo
	where Producto1.Id_Producto1 = @idProducto
	order by KARDEX.Id_kardex desc
	 