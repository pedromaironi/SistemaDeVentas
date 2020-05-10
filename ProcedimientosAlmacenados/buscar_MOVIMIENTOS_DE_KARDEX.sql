CREATE PROC [dbo].[buscar_MOVIMIENTOS_DE_KARDEX]
@idProducto int
AS BEGIN
SELECT       KARDEX.Fecha ,Producto1.Descripcion ,KARDEX.Motivo as Movimiento, KARDEX.Habia ,KARDEX.Tipo ,KARDEX.Cantidad ,KARDEX.Hay ,USUARIO2.Nombre_y_Apellido as Cajero ,Grupo_de_Productos.Linea as Categoria
,EMPRESA.Nombre_Empresa,EMPRESA.Logo 
FROM            dbo.KARDEX INNER JOIN Producto1 on Producto1.Id_Producto1=KARDEX.Id_producto inner join USUARIO2 on USUARIO2.idUsuario =KARDEX.Id_usuario 
               cross join EMPRESA
			INNER JOIN Grupo_de_Productos on
Grupo_de_Productos.Idline=Producto1.Id_grupo
						 
WHEre Producto1.Id_Producto1=@idProducto   order by KARDEX.Fecha Desc

END