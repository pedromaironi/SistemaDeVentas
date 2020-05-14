create proc insertar_Empresa
@Nombre_Empresa varchar (50),
@logo as image,
@Impuesto varchar(50),
@Porcentaje_impuesto numeric(18,0),
@Moneda varchar(50),

@Trabajas_con_impuestos varchar(50),
@Modo_de_busqueda varchar(50),
@Carpeta_para_copias_de_seguridad varchar(MAX),
@Correo_para_envio_de_reportes varchar(50),
@Ultima_fecha_de_copia_de_seguridad varchar(50),

@Ultima_fecha_de_copia_date datetime,
@Frecuencia_de_copias int,
@Estado varchar(50),
@Tipo_de_empresa varchar(50),

@Pais varchar(50),
@Redondeo_de_total varchar(50)

as 
if EXISTS (Select Nombre_Empresa from EMPRESA where Nombre_Empresa = @Nombre_Empresa)
RAISERROR ('YA EXISTE UNA EMPRESA CON ESE NOMBRE, Ingrese un nombre diferente', 16, 1)
else
insert into EMPRESA
VALUES (@Nombre_Empresa,@logo,@Impuesto,@Porcentaje_impuesto,@Moneda,@Trabajas_con_impuestos,@Modo_de_busqueda,
@Carpeta_para_copias_de_seguridad,@Correo_para_envio_de_reportes,@Ultima_fecha_de_copia_de_seguridad,@Ultima_fecha_de_copia_date,
@Frecuencia_de_copias,@Estado,@Tipo_de_empresa,@Pais,@Redondeo_de_total)
