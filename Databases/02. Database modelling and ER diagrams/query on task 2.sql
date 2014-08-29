SELECT p.FirstName + ' ' + p.LastName as [Name], cont.Name as [Continent], c.Name as [Country], t.Name as [Town], 
a.AddressText as [Address]
FROM Persons p
JOIN Addresses a
ON a.AddressId = p.AddressId
JOIN Towns t
ON t.TownId = a.TownId
JOIN Countries c
ON c.CountryId = t.CountryId
JOIN Continents cont
ON cont.ContinentId = c.ContinentId