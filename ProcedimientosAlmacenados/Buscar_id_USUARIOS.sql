create procedure [dbo].[Buscar_id_USUARIOS]
@Nombre_y_Apelllidos varchar(50)
as
select * from USUARIO2 
where Nombre_y_Apellido =@Nombre_y_Apelllidos
order by idUsuario desc