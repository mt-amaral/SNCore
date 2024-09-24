DECLARE @InsertedModel TABLE (Id INT);
DECLARE @InsertedOid TABLE (Id BIGINT, Oid VARCHAR(255));

INSERT INTO master.dbo.HostModel (CreationDate, ModelName, Active)
OUTPUT INSERTED.Id INTO @InsertedModel(Id)  
VALUES (GETDATE(), 'MikroTik', 1); 

DECLARE @ModelId1 INT;
SELECT @ModelId1 = Id FROM @InsertedModel;


DECLARE @Oids1 TABLE (Oid VARCHAR(255), Active BIT, ItemName VARCHAR(255));


INSERT INTO @Oids1 (Oid, ItemName, Active)
VALUES 
    ('1.1.1.1.11.1.1.1','Interface1', 1),
    ('1.1.1.1.11.1.1.2','Interface2', 1),
    ('1.1.1.1.11.1.1.3','Interface3', 1);

INSERT INTO master.dbo.OidList (Oid, Active)
OUTPUT INSERTED.ID, INSERTED.Oid INTO @InsertedOid(Id, Oid)
SELECT Oid, Active FROM @Oids1;

INSERT INTO master.dbo.Item (CreationDate, ModelId, Active, ItemName, OidId)
SELECT GETDATE(), @ModelId1, 1, o.ItemName, i.Id 
FROM @Oids1 o
JOIN @InsertedOid i ON o.Oid = i.Oid;