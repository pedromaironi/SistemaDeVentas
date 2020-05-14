create procedure [dbo].[Insertar_caja]

	
	@descripcion varchar(50),


	 @Tema varchar(50),
	  @Serial_PC varchar(50),
	   @Impresora_Ticket varchar(max),
	   @Impresora_A4 varchar(max),
	   @Tipo varchar(50)
    as

if EXISTS (SELECT  Descripcion,Serial_PC      FROM Caja    where  Descripcion=@descripcion and Serial_PC =@Serial_PC   )
RAISERROR ('Ya Existe una Caja con ese Nombre Ã³ puede ser que ya se haya creado una Caja para Esta Pc, Ingrese un nombre diferente e intente de Nuevo', 16,1)
else

declare @Estado as varchar(50)
set @Estado ='RECIEN CREADA'

    INSERT INTO Caja values 
	(@descripcion,@Tema ,@Serial_PC ,@Impresora_Ticket,@Impresora_A4,@Estado,@Tipo )

