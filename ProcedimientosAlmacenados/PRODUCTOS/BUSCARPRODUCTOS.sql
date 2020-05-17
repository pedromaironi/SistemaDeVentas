CREATE PROC BUSCAR_PRODUCTOS_oka
@letrab VARCHAR(50)
AS BEGIN 
SELECT TOP 10 Id_Producto1, (Descripcion+' /Precio: '+EMPRESA.Moneda + ' '+ CONVERT(varchar(50), Precio_de_venta) + ' /Codigo: '+Codigo ) as Descripcion
, Usa_inventarios, Stock, Precio_de_compra, Precio_de_venta, Codigo, Se_vende_a
FROM DBO.Producto1 cross join EMPRESA
Inner join Grupo_de_Productos on Grupo_de_Productos.Idline = Producto1.Id_grupo
where (Descripcion+' /Precio: '+EMPRESA.Moneda +' '+ CONVERT(varchar(50),Precio_de_venta) +' /Codigo: '+ Codigo ) LIKE '%' + @letrab+'%'
END 