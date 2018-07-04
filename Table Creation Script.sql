CREATE TABLE [dbo].[Person] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NOT NULL,
    [Phone]        NVARCHAR (50) NULL,
    [EmailAddress] NVARCHAR (50) NULL,
    [Status]       BIT           DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

