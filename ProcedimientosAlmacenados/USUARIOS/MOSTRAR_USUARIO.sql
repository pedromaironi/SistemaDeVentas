Create procedure mostrar_usuario 
as
select idUsuario, Nombre_y_Apellido as [Nombres], Login, Password
	, icono, Nombre_de_icono, Correo, Rol FROM USUARIO2
