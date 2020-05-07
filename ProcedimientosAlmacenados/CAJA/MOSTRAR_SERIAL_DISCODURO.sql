 
 Create proc mostrar_cajas_por_Serial_de_Disoduro
 @Serial as varchar(50)
 as
 select Caja.Id_Caja , Descripcion
 from Caja
 where caja.Serial_PC = @Serial

