create proc [dbo].[insertar_venta]
@idcliente as integer,
@fecha_venta as datetime,

@nume_documento as varchar(50),
@montototal  as numeric(18,2),
@Tipo_de_pago as varchar(50),
@estado as varchar(50),
@IGV as numeric(18, 1),

@Comprobante as VARCHAR(50),
@id_usuario as int,
@Fecha_de_pago as varchar(50),
@ACCION VARCHAR(50),
@Saldo numeric(18,2),
@Pago_con numeric(18,2),
@Porcentaje_IGV numeric(18,2),
@Id_caja int,
@Referencia_tarjeta varchar(50)

as 
declare @vuelto numeric(18,2)
declare @Efectivo numeric(18,2)
declare @id_numero varchar(50)
declare @Credito numeric(18,2)
declare @Tarjeta numeric(18,2)
SET @vuelto =0
SET @Efectivo =0
SET @id_numero= (select max(idventa)+1 from ventas )
SET @Credito =0
SET @Tarjeta =0
insert into ventas 
values (@idcliente,@fecha_venta,@nume_documento ,@montototal ,@Tipo_de_pago,@estado ,@IGV 
,@Comprobante +' '+ @id_numero ,@id_usuario,@Fecha_de_pago,@ACCION ,@Saldo,@Pago_con,@Porcentaje_IGV,
@Id_caja,@Referencia_tarjeta,
@vuelto ,@Efectivo,@Credito,@Tarjeta )