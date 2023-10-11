CREATE TABLE [dbo].[tb_factVenta_det] (
    [DocID]       INT             NOT NULL,
    [NumLinea]    INT             NOT NULL,
    [CodArticulo] INT             NOT NULL,
    [Cantidad]    INT             NOT NULL,
    [Precio]      NUMERIC (19, 6) NOT NULL,
    [Subtotal]    NUMERIC (19, 6) NOT NULL,
    FOREIGN KEY ([CodArticulo]) REFERENCES [dbo].[tb_articulo] ([CodArticulo]),
    FOREIGN KEY ([DocID]) REFERENCES [dbo].[tb_factVenta_cab] ([DocID])
);

