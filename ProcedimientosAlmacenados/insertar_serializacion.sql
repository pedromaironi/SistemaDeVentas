create procedure [dbo].[insertar_Serializacion]

@Serie varchar (50),
@numeroinicio as varchar (50),
@numerofin as varchar (50),
@Destino as varchar(50),
@tipodoc varchar(50)
,@Por_defecto varchar(50)
as 
if EXISTS (SELECT tipodoc  FROM Serializacion  where  tipodoc= @tipodoc )
RAISERROR ('YA EXISTE ESTE COMPROBANTE INGRESE UNO NUEVO', 16,1)
else

insert into Serializacion  values (@Serie ,
@numeroinicio ,
@numerofin,@Destino ,@tipodoc ,@Por_defecto)
