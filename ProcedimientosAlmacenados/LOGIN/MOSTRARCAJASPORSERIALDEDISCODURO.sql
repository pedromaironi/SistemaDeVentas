USE [BASESISTEMA]
GO
/****** Object:  StoredProcedure [dbo].[mostrar_cajas_por_Serial_de_Disoduro]    Script Date: 7/5/2020 8:49:15 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 ALTER proc [dbo].[mostrar_cajas_por_Serial_de_Disoduro]
 @Serial as varchar(50)
 as
 select Caja.Id_Caja , Descripcion
 from Caja
 where caja.Serial_PC = @Serial

