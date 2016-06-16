CREATE TABLE [dbo].[__MigrationHistory]
(
[MigrationId] [nvarchar] (150) COLLATE Modern_Spanish_CI_AS NOT NULL,
[ContextKey] [nvarchar] (300) COLLATE Modern_Spanish_CI_AS NOT NULL,
[Model] [varbinary] (max) NOT NULL,
[ProductVersion] [nvarchar] (32) COLLATE Modern_Spanish_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[__MigrationHistory] ADD CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED  ([MigrationId], [ContextKey]) ON [PRIMARY]
GO
