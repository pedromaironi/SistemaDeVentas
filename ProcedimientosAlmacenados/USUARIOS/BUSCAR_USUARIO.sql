Create procedure buscar_usuario 
@letra varchar(50)
as
select idUsuario, Nombre_y_Apellido as [Nombres], Login, Password, icono, Nombre_de_icono, Correo, Rol FROM USUARIO2
where Nombre_y_Apellido + Login Like '%' + @letra + '%';
