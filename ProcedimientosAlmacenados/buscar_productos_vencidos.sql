create proc buscar_productos_vencidos
@letra as varchar(50)
as

select Id_Producto1, Codigo, Descripcion
,Fecha_de_Vencimiento as F_vencimiento, Stock,EMPRESA.Nombre_Empresa, EMPRESA.Logo
, DATEDIFF(day, Fecha_de_vencimiento, CONVERT(DATE,GETDATE()))as [Dias Vencidos] from Producto1
cross join EMPRESA
where Descripcion + codigo LIKE '%' + @letra + '%' and Fecha_de_vencimiento <> 'NO APLICA' AND Fecha_de_vencimiento <= CONVERT(DATE,GETDATE())
order by(DATEDIFF(day,Fecha_de_vencimiento,CONVERT(DATE,GETDATE()))) asc 
