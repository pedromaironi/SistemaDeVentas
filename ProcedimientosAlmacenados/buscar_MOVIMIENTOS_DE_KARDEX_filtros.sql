CREATE PROC [dbo].[buscar_MOVIMIENTOS_DE_KARDEX_filtros ]
@fecha date,
@tipo varchar(50),
@Id_usuario int 
AS BEGIN
SELECT       KARDEX.Fecha ,Producto1.Descripcion ,KARDEX.Motivo as Movimiento, KARDEX.Habia ,KARDEX.Tipo ,KARDEX.Cantidad ,KARDEX.Hay ,USUARIO2.Nombres_y_Apellidos as Usuario ,Grupo_de_Productos .Linea as Categoria
,USUARIO2.idUsuario,@fecha as Fecha_consulta, @tipo as Tipo_consulta, EMPRESA.Nombre_Empresa ,EMPRESA.Logo 
 FROM            dbo.KARDEX INNER JOIN Producto1 on Producto1.Id_Producto1=KARDEX.Id_producto inner join USUARIO2 on USUARIO2.idUsuario =KARDEX.Id_usuario 
         INNER JOIN Grupo_de_Productos on Grupo_de_Productos.Idline=Producto1.Id_grupo 
						 CROSS JOIN EMPRESA 
WHEre KARDEX.Id_usuario =@Id_usuario and (KARDEX.Tipo=@tipo or @tipo ='-Todos-') and convert(date,KARDEX.Fecha) =convert(date,@fecha )
END