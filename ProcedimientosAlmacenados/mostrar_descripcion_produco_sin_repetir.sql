
CREATE PROC [dbo].[mostrar_descripcion_produco_sin_repetir]

@buscar varchar(50)
as begin
select TOP 10 Descripcion  from Producto1  Where Descripcion  LIKE  '%' + @buscar +'%'
end
