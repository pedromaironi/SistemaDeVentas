CREATE proc [dbo].[insertar_inicio_De_sesion]

 
 @Id_serial_Pc varchar(max)

  as
  declare @id_usuario_nuevo as int
  set @id_usuario_nuevo = (SELECT idUsuario  FROM USUARIO2  )

insert into Inicios_de_sesion_por_caja

values (@Id_serial_Pc,@id_usuario_nuevo )
