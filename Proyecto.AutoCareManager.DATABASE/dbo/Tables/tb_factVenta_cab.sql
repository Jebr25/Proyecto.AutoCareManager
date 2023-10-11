CREATE TABLE [dbo].[tb_factVenta_cab] (
    [DocID]          INT             IDENTITY (1, 1) NOT NULL,
    [CodSN]          INT             NOT NULL,
    [FecDocumento]   DATETIME        NOT NULL,
    [FecVencimiento] DATETIME        NOT NULL,
    [ProxFecMant]    DATETIME        NOT NULL,
    [CondicionPago]  NVARCHAR (100)  NULL,
    [Moneda]         NVARCHAR (3)    NOT NULL,
    [NumSerieFiscal] NVARCHAR (4)    NOT NULL,
    [NumCorrelativo] NVARCHAR (8)    NOT NULL,
    [Comentarios]    NVARCHAR (254)  NULL,
    [DocTotal]       NUMERIC (19, 6) NOT NULL,
    [CodEmpleado]    INT             NOT NULL,
    [ActID]          INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([DocID] ASC),
    FOREIGN KEY ([ActID]) REFERENCES [dbo].[tb_actServicio] ([ActID]),
    FOREIGN KEY ([CodEmpleado]) REFERENCES [dbo].[tb_empleado] ([CodEmpleado]),
    FOREIGN KEY ([CodSN]) REFERENCES [dbo].[tb_socio_de_negocio] ([CodSN])
);

