create procedure eliminar_usuario
@idUsuario int,
@login varchar(50)
as
if exists(select login from USUARIO2 where @login = 'admin')
raiserror('EL USUARIO *admin* NO SE PUEDE ELIMINAR, SE ELIMINARIA EL ACCESO AL SISTEMA ',16,1)
else
delete from USUARIO2 where idUsuario = @idUsuario AND Login <> 'admin'