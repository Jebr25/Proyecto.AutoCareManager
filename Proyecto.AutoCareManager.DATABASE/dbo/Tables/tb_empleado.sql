CREATE TABLE [dbo].[tb_empleado] (
    [CodEmpleado] INT            IDENTITY (1, 1) NOT NULL,
    [Nombres]     NVARCHAR (100) NOT NULL,
    [Apellidos]   NVARCHAR (100) NOT NULL,
    [NumIdent]    NVARCHAR (32)  NOT NULL,
    [Cargo]       NVARCHAR (100) NULL,
    [Estado]      NVARCHAR (1)   NOT NULL,
    [CodTaller]   INT            NOT NULL,
    [USER_CODE]   INT            NULL,
    PRIMARY KEY CLUSTERED ([CodEmpleado] ASC),
    FOREIGN KEY ([CodTaller]) REFERENCES [dbo].[tb_taller] ([CodTaller]),
    FOREIGN KEY ([USER_CODE]) REFERENCES [dbo].[tb_usuario] ([USER_CODE])
);

