CREATE TABLE [dbo].[SAIR_TYPES]
(
[TYPE_cCodTable] [nvarchar] (4) COLLATE Modern_Spanish_CI_AS NOT NULL,
[TYPE_cCodType] [nvarchar] (4) COLLATE Modern_Spanish_CI_AS NOT NULL,
[TYPE_cDescription] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL,
[TYPE_cNotes] [nvarchar] (200) COLLATE Modern_Spanish_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SAIR_TYPES] ADD CONSTRAINT [SAIR_TYPE_PK] PRIMARY KEY CLUSTERED  ([TYPE_cCodTable], [TYPE_cCodType]) ON [PRIMARY]
GO
