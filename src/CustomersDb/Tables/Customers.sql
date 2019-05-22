CREATE TABLE [dbo].[Customers]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(100) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL
)

GO

CREATE UNIQUE INDEX [IX_Customers_EmailAddress] ON [dbo].[Customers] ([EmailAddress])
