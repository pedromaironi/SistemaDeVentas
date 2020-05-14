CREATE procedure [dbo].[editar_caja]
@idcaja integer,
@descripcion varchar(50)

 as       
 if EXISTS (SELECT Descripcion  FROM Caja  where (Descripcion  = @descripcion and Id_Caja  <>@idcaja ) )

RAISERROR ('YA EXISTE UN REGISTRO  CON ESTE NOMBRE, POR FAVOR INGRESE DE NUEVO', 16,1)
else          		
 
update Caja set 
Descripcion  =@descripcion 

where Id_Caja    =@idcaja   
GO