Create procedure insertar_usuario 
@nombres varchar(50),
@Login varchar(50),
@Password varchar(50),
@icono image,
@Nombre_de_icono varchar(MAX),
@Correo varchar(MAX),
@Rol varchar(max)
as
if exists (select Login FROM USUARIO2 where Login = @Login and Nombre_de_icono = @Nombre_de_icono)
raiserror('YA EXISTE UN USUARIO CON ESE LOGIN O CON ESE ICONO, POR FAVOR INGRESE DE NUEVO',16,1)
ELSE
insert into USUARIO2
values(@nombres,@Login,@Password,@icono,@nombre_de_icono,@Correo,@Rol)
