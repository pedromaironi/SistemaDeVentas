Create proc eliminar_producto
@idproducto int
as
delete from Producto1 where Id_Producto1 = @idproducto