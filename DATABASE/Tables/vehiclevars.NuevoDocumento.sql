CREATE TABLE [vehiclevars].[NuevoDocumento]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[SAIR_VEHIID] [int] NOT NULL,
[Responsable] [nvarchar] (240) COLLATE Modern_Spanish_CI_AS NULL,
[Encargado] [nvarchar] (240) COLLATE Modern_Spanish_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [vehiclevars].[NuevoDocumento] ADD CONSTRAINT [vehiclevarsNuevoDocumentoPK] PRIMARY KEY CLUSTERED  ([SAIR_VEHIID]) ON [PRIMARY]
GO
ALTER TABLE [vehiclevars].[NuevoDocumento] ADD CONSTRAINT [vehiclevarNuevoDocumento_VEHI_FK] FOREIGN KEY ([SAIR_VEHIID]) REFERENCES [dbo].[SAIR_VEHICLE] ([Codigo])
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nuevo Documento', 'SCHEMA', N'vehiclevars', 'TABLE', N'NuevoDocumento', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', N'Encargado', 'SCHEMA', N'vehiclevars', 'TABLE', N'NuevoDocumento', 'COLUMN', N'Encargado'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Responsable', 'SCHEMA', N'vehiclevars', 'TABLE', N'NuevoDocumento', 'COLUMN', N'Responsable'
GO
