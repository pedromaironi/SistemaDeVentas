CREATE procedure [dbo].[EDITAR_marcan_a]

	@e varchar(max),
	@fa varchar(max),
	@f  varchar(max),
	@s varchar(max)
    as
	
    UPDATE Marcan SET E=@e, FA=@fa, F=@f 
	where S=@s 