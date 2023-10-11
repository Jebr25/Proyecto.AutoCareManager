CREATE TABLE [dbo].[tb_usuario] (
    [USER_CODE]    INT            IDENTITY (1, 1) NOT NULL,
    [Email]        NVARCHAR (100) NOT NULL,
    [PASSWORD]     NVARCHAR (254) NOT NULL,
    [FirmaUsuario] NVARCHAR (100) NOT NULL,
    [Nombres]      NVARCHAR (100) NOT NULL,
    [Apellidos]    NVARCHAR (100) NOT NULL,
    [TipoUsuario]  NVARCHAR (1)   NOT NULL,
    PRIMARY KEY CLUSTERED ([USER_CODE] ASC)
);

