CREATE proc editar_dinero_caja_inicial
@Id_caja as integer,
@saldo numeric(18,2)


as
update MOVIMIENTOCAJACIERRE  set  Saldo_queda_en_caja = @saldo
where Id_caja =@Id_caja AND Estado ='CAJA APERTURADA'