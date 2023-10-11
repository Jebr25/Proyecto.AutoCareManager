CREATE TABLE [dbo].[tb_articulo_taller] (
    [CodArticulo] INT NOT NULL,
    [CodTaller]   INT NOT NULL,
    [Stock]       INT NOT NULL,
    FOREIGN KEY ([CodArticulo]) REFERENCES [dbo].[tb_articulo] ([CodArticulo]),
    FOREIGN KEY ([CodTaller]) REFERENCES [dbo].[tb_taller] ([CodTaller])
);

