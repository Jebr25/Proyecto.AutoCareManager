CREATE TABLE [dbo].[tb_actServicio] (
    [ActID]             INT            IDENTITY (1, 1) NOT NULL,
    [FecInicio]         DATETIME       NOT NULL,
    [FecFin]            DATETIME       NOT NULL,
    [CodVehiculo]       INT            NOT NULL,
    [DetalleReparacion] NVARCHAR (254) NOT NULL,
    [Estado]            NVARCHAR (7)   NULL,
    PRIMARY KEY CLUSTERED ([ActID] ASC),
    FOREIGN KEY ([CodVehiculo]) REFERENCES [dbo].[tb_vehiculo] ([CodVehiculo])
);

