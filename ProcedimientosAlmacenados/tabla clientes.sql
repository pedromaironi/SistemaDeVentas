CREATE TABLE [dbo].[clientes](
	[idclientev] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Direccion_para_factura] [varchar](max) NULL,
	[Ruc] [varchar](max) NULL,
	[movil] [varchar](50) NULL,
	[Cliente] [varchar](50) NULL,
	[Proveedor] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[Saldo] [numeric](18, 2) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[idclientev] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]