create proc [dbo].[insertar_Empresa]
@Nombre_Empresa  varchar(50),
@logo as image,
@Impuesto varchar(50),
@Porcentaje_impuesto numeric(18,0),
@Moneda varchar(50),

@Trabajas_con_impuestos VARCHAR(50),
@Modo_de_busqueda VARCHAR(50),
@Carpeta_para_copias_de_seguridad varchar(max),
@Correo_para_envio_de_reportes varchar(50),
@Ultima_fecha_de_copia_de_seguridad varchar(50),

@Ultima_fecha_de_copia_date datetime,
@Frecuencia_de_copias int,
@Estado varchar(50),
@Tipo_de_empresa varchar(50),
@Pais varchar(max),
@Redondeo_de_total varchar(50)

as
if EXISTS (SELECT Nombre_Empresa   FROM EMPRESA   where Nombre_Empresa  = @Nombre_Empresa   )
RAISERROR ('YA EXISTE UNA EMPRESA CON ESE NOMBRE, Ingrese un nombre diferente', 16,1)
else
insert into EMPRESA 
VALUES (@Nombre_Empresa,@logo,@Impuesto,@Porcentaje_impuesto,@Moneda ,@Trabajas_con_impuestos,@Modo_de_busqueda,
@Carpeta_para_copias_de_seguridad,@Correo_para_envio_de_reportes,@Ultima_fecha_de_copia_de_seguridad,
@Ultima_fecha_de_copia_date ,
@Frecuencia_de_copias ,
@Estado ,@Tipo_de_empresa,@Pais,@Redondeo_de_total)


GO
/****** Object:  StoredProcedure [dbo].[Insertar_FORMATO_TICKET]    Script Date: 27/11/2019 18:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Insertar_FORMATO_TICKET]

  
	  @Identificador_fiscal varchar(max),
           @Direccion varchar(max),
         
           @Provincia_Departamento_Pais varchar(max),
           @Nombre_de_Moneda varchar(max),
           @Agradecimiento varchar(max),
           @pagina_Web_Facebook varchar(max),
           @Anuncio varchar(max),
	   @Datos_fiscales_de_autorizacion varchar(max),
	   @Por_defecto as varchar(max)
	  
    as
	 DECLARE @Id_Empresa int  = (Select Id_empresa from EMPRESA )
    INSERT INTO Ticket values 

	(  
	@Id_Empresa ,
	  @Identificador_fiscal ,
           @Direccion,
         
           @Provincia_Departamento_Pais,
           @Nombre_de_Moneda ,
           @Agradecimiento ,
           @pagina_Web_Facebook ,
           @Anuncio,
	   @Datos_fiscales_de_autorizacion,
	   @Por_defecto )
