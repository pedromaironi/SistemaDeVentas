USE [BASESISTEMA]
GO
/****** Object:  StoredProcedure [dbo].[editar_usuario]    Script Date: 5/5/2020 12:25:20 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[editar_usuario] 
@idUsuario int,
@nombres varchar(50),
@Login varchar(50),
@Password varchar(50),
@icono image,
@Nombre_de_icono varchar(MAX),
@Correo varchar(MAX),
@Rol varchar(max)
as
if exists (select Login,idUsuario FROM USUARIO2 where (Login = @Login and idUsuario<>@idUsuario and Estado = 'ACTIVO') or 
(Nombre_y_Apellido = @nombres and idUsuario <> @idUsuario and Estado = 'ACTIVO'))
raiserror('YA EXISTE UN USUARIO CON ESE LOGIN O CON ESE ICONO, POR FAVOR INGRESE DE NUEVO',16,1)
ELSE
update USUARIO2 set Nombre_y_Apellido = @nombres, Password = @Password, icono = @icono, Nombre_de_icono = @Nombre_de_icono,
	Correo = @Correo, Rol = @Rol, Login = @Login
	where idUsuario = @idUsuario