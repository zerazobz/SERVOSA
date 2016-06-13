CREATE TABLE [dbo].[SAIR_DriverAlerts]
(
[VEAL_Id] [int] NOT NULL IDENTITY(1, 1),
[VEAL_TableName] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL,
[VEAL_DaysToAlert] [int] NOT NULL,
[VEAL_DateToAlert] [datetime] NULL,
[VEAL_AlertName] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL,
[VEAL_AlertSended] [bit] NULL,
[VEHI_ID] [int] NOT NULL,
[VEAL_TokenSMS] [nvarchar] (80) COLLATE Modern_Spanish_CI_AS NULL,
[VEAL_SendDate] [datetime] NULL,
[VEAL_Recipients] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[SAIR_DriverAlerts] ADD CONSTRAINT [SAIR_DRAL_PK] PRIMARY KEY CLUSTERED  ([VEAL_Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SAIR_DriverAlerts] ADD CONSTRAINT [SAIR_DRAL_FK_SAIR_DRIV] FOREIGN KEY ([VEHI_ID]) REFERENCES [dbo].[SAIR_DRIVER] ([Codigo])
GO
