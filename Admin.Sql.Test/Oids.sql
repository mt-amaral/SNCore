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
     -- System
    ('.1.3.6.1.2.1.1.3.0', 'Uptime', 1),
    ('.1.3.6.1.2.1.1.5.0', 'Identirty', 1),
    ('.1.3.6.1.2.1.2.2.1.2', 'List all Interfaces', 1),
    ('.1.3.6.1.2.1.1.1.0', 'Model', 1),


    -- Interfaces Discover
    ('.1.3.6.1.2.1.31.1.1.1.1','List All Interfaces 2', 1),

    -- CPU
    ('.1.3.6.1.2.1.47.1.1.1.1.7.65536', 'CPU Info', 1),
    ('.1.3.6.1.4.1.14988.1.1.3.14.0', 'CPU Frequency', 1),
    
    
    -- Memory
    ('.1.3.6.1.2.1.25.2.3.1.5.65536', 'Total Memory', 1),
    ('.1.3.6.1.2.1.25.2.3.1.6.65536', 'Use Memory', 1),
    ('.1.3.6.1.2.1.25.2.3.1.5.131072', 'Total System Disk', 1),
    ('.1.3.6.1.2.1.25.2.3.1.6.131072', 'Use System Disk', 1);
    

INSERT INTO master.dbo.OidList (Oid, Active)
OUTPUT INSERTED.ID, INSERTED.Oid INTO @InsertedOid(Id, Oid)
SELECT Oid, Active FROM @Oids1;

INSERT INTO master.dbo.Item (CreationDate, ModelId, Active, ItemName, OidId)
SELECT GETDATE(), @ModelId1, 1, o.ItemName, i.Id 
FROM @Oids1 o
JOIN @InsertedOid i ON o.Oid = i.Oid;