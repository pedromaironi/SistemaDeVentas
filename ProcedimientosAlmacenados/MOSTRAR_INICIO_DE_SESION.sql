create proc [dbo].[mostrar_inicio_De_sesion]
  @id_serial_pc as varchar(max)
  as
select Id_usuario  from Inicios_de_sesion_por_caja 
where Id_serial_Pc =@id_serial_pc 