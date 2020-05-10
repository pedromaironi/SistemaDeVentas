create PROC [dbo].[mostrar_inventarios_todos]

@letra varchar(50)
AS 
SELECT    Codigo ,Descripcion,Precio_de_compra as Costo,Precio_de_venta as [Precio_Venta], Stock, Stock_minimo as [Stock_Minimo]
,Grupo_de_Productos.Linea  AS Categoria ,Precio_de_compra*Stock as Importe,EMPRESA.Nombre_Empresa,EMPRESA.Logo 
FROM         
						 dbo.Producto1 
						  cross join EMPRESA
						   inner join Grupo_de_Productos on Grupo_de_Productos.Idline=Producto1.Id_grupo 
where Descripcion+Codigo   LIKE  '%' + @letra+'%' AND Producto1.Usa_inventarios ='SI'