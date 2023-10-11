CREATE TABLE [dbo].[tb_articulo] (
    [CodArticulo]      INT            IDENTITY (1, 1) NOT NULL,
    [DesArticulo]      NVARCHAR (254) NOT NULL,
    [ArtInventariable] NVARCHAR (1)   NOT NULL,
    [TipoServicio]     NVARCHAR (1)   NOT NULL,
    [UnidadMedida]     NVARCHAR (40)  NULL,
    [Fabricante]       NVARCHAR (254) NULL,
    [ImpVenta]         NVARCHAR (8)   NOT NULL,
    [Estado]           NVARCHAR (1)   NOT NULL,
    PRIMARY KEY CLUSTERED ([CodArticulo] ASC)
);

