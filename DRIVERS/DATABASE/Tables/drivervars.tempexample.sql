CREATE TABLE [drivervars].[tempexample]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Description] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [drivervars].[tempexample] ADD CONSTRAINT [PK__tempexam__3214EC075B2AEEF4] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
