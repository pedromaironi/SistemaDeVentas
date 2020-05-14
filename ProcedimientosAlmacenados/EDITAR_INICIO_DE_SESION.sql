create proc [dbo].[editar_inicio_De_sesion]

 
 @Id_serial_Pc varchar(max),
 @id_usuario int
  as
update Inicios_de_sesion_por_caja set 
Id_usuario =@id_usuario 
where Id_serial_Pc=@Id_serial_Pc 