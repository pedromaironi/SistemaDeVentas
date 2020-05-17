create proc restaurar_caja
@idcaja integer
as
update Caja set
Estado = 'Caja Restaurada'
where Id_Caja = @idcaja