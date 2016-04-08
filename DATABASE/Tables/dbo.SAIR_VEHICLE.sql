CREATE TABLE [dbo].[SAIR_VEHICLE]
(
[Item] [int] NOT NULL CONSTRAINT [SAIR_VEHIDF_ItemValores] DEFAULT (NEXT VALUE FOR [SAIR_VALUESFORVEHICLEITEM]),
[Codigo] [int] NOT NULL IDENTITY(1, 1),
[PlacaTracto] [nvarchar] (30) COLLATE Modern_Spanish_CI_AS NULL,
[PlacaTolva] [nvarchar] (30) COLLATE Modern_Spanish_CI_AS NULL,
[CodigoMarca] [int] NOT NULL,
[CodigoEstado] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SAIR_VEHICLE] ADD CONSTRAINT [SAIR_VEHIPK] PRIMARY KEY CLUSTERED  ([Codigo]) ON [PRIMARY]
GO
