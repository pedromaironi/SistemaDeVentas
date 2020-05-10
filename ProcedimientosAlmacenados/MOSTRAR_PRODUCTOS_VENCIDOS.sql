create proc mostrar_productos_vencidos
as

select Id_Producto1, Codigo, Descripcion
,Fecha_de_vencimiento as F_vencimiento, Stock
,DATEDIFF(day,Fecha_de_vencimiento, CONVERT(DATE,GETDATE())) AS [Dias Vencidos]
from Producto1 
where Fecha_de_vencimiento <> 'NO APLICA' AND Fecha_de_vencimiento <= CONVERT(DATE,GETDATE())