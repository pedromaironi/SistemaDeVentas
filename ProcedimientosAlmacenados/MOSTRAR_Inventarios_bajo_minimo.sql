create PROC [dbo].[MOSTRAR_Inventarios_bajo_minimo]
AS
select  Codigo,Descripcion,Precio_de_compra AS [Precio_de_Compra],Grupo_de_Productos. linea as Categoria,
 Stock ,Stock_minimo as [Stock_Minimo],Grupo_de_Productos. linea,EMPRESA.Nombre_Empresa,EMPRESA.Logo  
 from Producto1 cross join EMPRESA
				inner join Grupo_de_Productos on Grupo_de_Productos.Idline=Producto1.Id_grupo 
				where Stock <= Stock_minimo 	and Usa_inventarios ='SI'