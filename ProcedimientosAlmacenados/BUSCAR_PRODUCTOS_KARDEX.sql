CREATE procedure [dbo].[BUSCAR_PRODUCTOS_KARDEX]

@letrab VARCHAR(50)
AS 
SELECT       top 10 Id_Producto1, (Descripcion) AS Descripcion, Imagen, Grupo_de_Productos.Linea, Usa_inventarios, Stock, Precio_de_compra, Fecha_de_vencimiento, Precio_de_venta, Codigo, Se_vende_a, Impuesto, Stock_minimo, Precio_mayoreo, Sub_total_pv, 
                         Sub_total_pm
FROM            dbo.Producto1 
                      	INNER JOIN Grupo_de_Productos on
Grupo_de_Productos.Idline=Producto1.Id_grupo
  
						 where  (Descripcion+Grupo_de_Productos.Linea  + Codigo) LIKE  '%' + @letrab+'%' and Usa_inventarios ='SI'
