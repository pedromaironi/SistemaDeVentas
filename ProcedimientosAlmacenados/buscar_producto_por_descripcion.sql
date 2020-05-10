create PROC [dbo].[buscar_producto_por_descripcion]
@letra VARCHAR(50)
AS BEGIN
select top 10 Id_Producto1,Codigo , Grupo_de_Productos.Linea as Grupo,Descripcion ,Impuesto,Usa_inventarios ,Precio_de_compra AS P_Compra,Precio_mayoreo as P_mayoreo,Se_vende_a as Se_vende_por,Stock_minimo ,Fecha_de_vencimiento as F_vencimiento ,Stock,Precio_de_venta as P_venta 
,Grupo_de_Productos.Idline,A_partir_de 

FROM            dbo.Producto1 
INNER JOIN Grupo_de_Productos on
Grupo_de_Productos.Idline=Producto1.Id_grupo
              
WHEre (dbo.Producto1.Descripcion)+Codigo +Grupo_de_Productos.Linea   LIKE  '%' + @letra+'%' ORDER BY DBO.Producto1.Descripcion  asc
 
END