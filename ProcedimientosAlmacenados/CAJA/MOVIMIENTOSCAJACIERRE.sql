Create Proc MOSTRAR_MOVIMIENTOS_DE_CAJA_POR_SERIAL

@serial varchar(50)

as
SELECT USUARIO2.Login,USUARIO2.Nombres_y_Apellidos    FROM MOVIMIENTOCAJACIERRE inner join USUARIO2 on USUARIO2.idUsuario=MOVIMIENTOCAJACIERRE.Id_usuario
 inner join Caja on Caja.Id_Caja =MOVIMIENTOCAJACIERRE.Id_caja 
 where Caja.Serial_PC = @serial    AND MOVIMIENTOCAJACIERRE.Estado='CAJA APERTURADA' and MOVIMIENTOCAJACIERRE.Id_usuario = @idusuario and USUARIO2.Estado ='ACTIVO'
