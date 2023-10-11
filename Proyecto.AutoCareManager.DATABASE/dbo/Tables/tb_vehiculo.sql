CREATE TABLE [dbo].[tb_vehiculo] (
    [CodVehiculo] INT            IDENTITY (1, 1) NOT NULL,
    [Placa]       NVARCHAR (7)   NOT NULL,
    [Marca]       NVARCHAR (32)  NULL,
    [Modelo]      NVARCHAR (100) NULL,
    [Año]         NVARCHAR (4)   NULL,
    [FecUltMant]  DATETIME       NULL,
    [CodSN]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([CodVehiculo] ASC),
    FOREIGN KEY ([CodSN]) REFERENCES [dbo].[tb_socio_de_negocio] ([CodSN])
);

