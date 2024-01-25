CREATE TABLE [dbo].[User] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (20)  NOT NULL,
    [Password]     NVARCHAR (100) NULL,
    [GradeTypeId]  INT            CONSTRAINT [DF_User_Grade] DEFAULT ((1)) NOT NULL,
    [UseFlag]      [dbo].[Flag]   CONSTRAINT [DF_Users_UseFlag] DEFAULT ((1)) NOT NULL,
    [InsertUserId] INT            NULL,
    [InsertDate]   DATETIME       CONSTRAINT [DF_User_InsertDate] DEFAULT (getutcdate()) NOT NULL,
    [UpdateUserId] INT            NULL,
    [UpdateDate]   DATETIME       CONSTRAINT [DF_User_UpdateDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_GradeType] FOREIGN KEY ([GradeTypeId]) REFERENCES [dbo].[GradeType] ([Id])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사용자', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'사용자', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User', @level2type = N'COLUMN', @level2name = N'UserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'비밀번호', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User', @level2type = N'COLUMN', @level2name = N'Password';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1=관리자, 2=사용자, 사용자 등급', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User', @level2type = N'COLUMN', @level2name = N'GradeTypeId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1 = use, 0 = not use', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'User', @level2type = N'COLUMN', @level2name = N'UseFlag';

