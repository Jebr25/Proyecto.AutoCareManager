CREATE TABLE [dbo].[tb_taller] (
    [CodTaller] INT            IDENTITY (1, 1) NOT NULL,
    [DesTaller] NVARCHAR (200) NOT NULL,
    [Direccion] NVARCHAR (254) NULL,
    [Ciudad]    NVARCHAR (254) NULL,
    [País]      NVARCHAR (254) NULL,
    PRIMARY KEY CLUSTERED ([CodTaller] ASC)
);

