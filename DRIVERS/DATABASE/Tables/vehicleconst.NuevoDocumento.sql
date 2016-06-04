CREATE TABLE [vehicleconst].[NuevoDocumento]
(
[cid] [int] NOT NULL IDENTITY(1, 1),
[CSAIR_VEHIID] [int] NOT NULL,
[DiasAlerta] [int] NULL,
[RutaDocumento] [nvarchar] (800) COLLATE Modern_Spanish_CI_AS NULL,
[FechaVencimiento] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [vehicleconst].[NuevoDocumento] ADD CONSTRAINT [vehicleconstNuevoDocumentoPK] PRIMARY KEY CLUSTERED  ([CSAIR_VEHIID]) ON [PRIMARY]
GO
ALTER TABLE [vehicleconst].[NuevoDocumento] ADD CONSTRAINT [vehicleconstNuevoDocumento_VEHI_FK] FOREIGN KEY ([CSAIR_VEHIID]) REFERENCES [dbo].[SAIR_VEHICLE] ([Codigo])
GO
