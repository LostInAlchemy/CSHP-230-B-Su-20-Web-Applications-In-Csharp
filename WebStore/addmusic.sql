USE ProductDb
GO

insert into [dbo].[Category] 

values
(
'Music'
)

insert into [dbo].[Product] (
[ProductName], [ProductPrice], [ProductQuantity])
values
('Drums', 100, 2),
('Bass', 1150, 10)
GO