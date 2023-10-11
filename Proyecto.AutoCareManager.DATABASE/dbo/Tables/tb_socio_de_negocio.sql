CREATE TABLE [dbo].[tb_socio_de_negocio] (
    [CodSN]           INT            IDENTITY (1, 1) NOT NULL,
    [RazonSocial]     NVARCHAR (100) NOT NULL,
    [NumIdent]        NVARCHAR (32)  NOT NULL,
    [PersonaContacto] NVARCHAR (100) NULL,
    [Telefono]        NVARCHAR (32)  NULL,
    [Email]           NVARCHAR (100) NOT NULL,
    [Direccion]       NVARCHAR (254) NULL,
    [Estado]          NVARCHAR (1)   NOT NULL,
    [USER_CODE]       INT            NULL,
    PRIMARY KEY CLUSTERED ([CodSN] ASC),
    FOREIGN KEY ([USER_CODE]) REFERENCES [dbo].[tb_usuario] ([USER_CODE])
);

