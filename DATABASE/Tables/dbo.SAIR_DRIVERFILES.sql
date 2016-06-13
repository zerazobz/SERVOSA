CREATE TABLE [dbo].[SAIR_DRIVERFILES]
(
[VEFI_Identity] [int] NOT NULL IDENTITY(1, 1),
[VEHI_VEHIID] [int] NOT NULL,
[VEFI_TableName] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NOT NULL,
[VEFI_DataFile] [binary] (1) NULL,
[VEFI_FileName] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NOT NULL,
[VEFI_FileContentType] [nvarchar] (40) COLLATE Modern_Spanish_CI_AS NULL,
[VEFI_FileLocationStored] [nvarchar] (360) COLLATE Modern_Spanish_CI_AS NULL,
[VEFI_DateCreated] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SAIR_DRIVERFILES] ADD CONSTRAINT [SAIR_DRFIPK] PRIMARY KEY CLUSTERED  ([VEHI_VEHIID], [VEFI_TableName], [VEFI_FileName]) ON [PRIMARY]
GO
