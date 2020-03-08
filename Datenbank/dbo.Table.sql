CREATE TABLE [dbo].Player
(
	[Playername] TEXT NOT NULL PRIMARY KEY UNIQUE, 
    [Wins] INT NULL DEFAULT 0, 
    [Loss] INT NULL DEFAULT 0, 
    [Top Wins] INT NULL DEFAULT 0, 
    [Top Looses] INT NULL DEFAULT 0,
	[jungle Wins] INT NULL DEFAULT 0, 
    [jungle Looses] INT NULL DEFAULT 0,
	[Mid Wins] INT NULL DEFAULT 0, 
    [Mid Looses] INT NULL DEFAULT 0,
	[ADC Wins] INT NULL DEFAULT 0, 
    [ADC Looses] INT NULL DEFAULT 0,
	[Support Wins] INT NULL DEFAULT 0, 
    [Support Looses] INT NULL DEFAULT 0
)
