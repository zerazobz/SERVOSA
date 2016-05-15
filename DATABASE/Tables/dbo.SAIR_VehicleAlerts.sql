CREATE TABLE [dbo].[SAIR_VehicleAlerts]
(
[VEAL_Id] [int] NOT NULL IDENTITY(1, 1),
[VEAL_TableName] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL,
[VEAL_DaysToAlert] [int] NOT NULL,
[VEAL_DateToAlert] [datetime] NULL,
[VEAL_AlertName] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL,
[VEAL_AlertSended] [bit] NULL,
[VEHI_ID] [int] NOT NULL,
[VEAL_TokenSMS] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SAIR_VehicleAlerts] ADD CONSTRAINT [SAIR_VEAL_PK] PRIMARY KEY CLUSTERED  ([VEAL_Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SAIR_VehicleAlerts] ADD CONSTRAINT [SAIR_VEAL_FK_SAIR_VEHI] FOREIGN KEY ([VEHI_ID]) REFERENCES [dbo].[SAIR_VEHICLE] ([Codigo])
GO
