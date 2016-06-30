CREATE TABLE [dbo].[Settings]
(
	[SettingKey] varchar(60) NOT NULL,
	[Value] varchar(120),
	[ApplicationName] VARCHAR(120),
	[IsActive] bit NOT NULL, 
    [IsValueEncrypted] BIT NOT NULL, 
    CONSTRAINT [PK_Settings] PRIMARY KEY ([SettingKey])
)
