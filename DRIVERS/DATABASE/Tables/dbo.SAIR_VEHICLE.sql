CREATE TABLE [dbo].[SAIR_VEHICLE]
(
[Item] [int] NOT NULL CONSTRAINT [SAIR_VEHIDF_ItemValores] DEFAULT (NEXT VALUE FOR [SAIR_VALUESFORVEHICLEITEM]),
[Codigo] [int] NOT NULL IDENTITY(1, 1),
[TYPE_cTABBRND] [nvarchar] (4) COLLATE Modern_Spanish_CI_AS NULL,
[TYPE_cCODBRND] [nvarchar] (4) COLLATE Modern_Spanish_CI_AS NULL,
[TYPE_cTABVSTA] [nvarchar] (4) COLLATE Modern_Spanish_CI_AS NULL,
[TYPE_cCODVSTA] [nvarchar] (4) COLLATE Modern_Spanish_CI_AS NULL,
[VEHI_UnitType] [nvarchar] (1) COLLATE Modern_Spanish_CI_AS NULL,
[VEHI_VehiclePlate] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[SAIR_VEHICLE] ADD
CONSTRAINT [VEHI_CK_UnitType] CHECK (([VEHI_UnitType]='S' OR [VEHI_UnitType]='R'))
ALTER TABLE [dbo].[SAIR_VEHICLE] ADD
CONSTRAINT [SAIR_VEHIFK_TYPE] FOREIGN KEY ([TYPE_cTABBRND], [TYPE_cCODBRND]) REFERENCES [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType])
ALTER TABLE [dbo].[SAIR_VEHICLE] ADD
CONSTRAINT [SAIR_VEHIFK_TYPESTATE] FOREIGN KEY ([TYPE_cTABVSTA], [TYPE_cCODVSTA]) REFERENCES [dbo].[SAIR_TYPES] ([TYPE_cCodTable], [TYPE_cCodType])
GO
ALTER TABLE [dbo].[SAIR_VEHICLE] ADD CONSTRAINT [SAIR_VEHIPK] PRIMARY KEY CLUSTERED  ([Codigo]) ON [PRIMARY]
GO
