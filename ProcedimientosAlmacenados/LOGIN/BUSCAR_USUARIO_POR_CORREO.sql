create procedure buscar_usuario_por_correo
@correo VARCHAR(MAX)

as
select Password 
from USUARIO2
where Correo = @correo