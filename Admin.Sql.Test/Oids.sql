DECLARE @InsertedModel TABLE (Id INT);
DECLARE @InsertedOid TABLE (Id BIGINT, Oid VARCHAR(255));

INSERT INTO master.dbo.HostModel (ModelName, SrcIcon)
OUTPUT INSERTED.Id INTO @InsertedModel(Id)  
VALUES ('MikroTik', 'icons/mikrotik-icon.png'); 

DECLARE @ModelId1 INT;
SELECT @ModelId1 = Id FROM @InsertedModel;

DECLARE @Oids1 TABLE (Oid VARCHAR(255), ItemName VARCHAR(255));

INSERT INTO @Oids1 (Oid, ItemName)
VALUES
    -- System
    ('.1.3.6.1.2.1.1.3.0', 'Uptime'),
    ('.1.3.6.1.2.1.1.5.0', 'Identirty'),
    ('.1.3.6.1.2.1.2.2.1.2', 'List all Interfaces'),
    ('.1.3.6.1.2.1.1.1.0', 'Model'),

    -- Interfaces Discover
    ('.1.3.6.1.2.1.31.1.1.1.1', 'List All Interfaces 2'),

    -- CPU
    ('.1.3.6.1.2.1.47.1.1.1.1.7.65536', 'CPU Info'),
    ('.1.3.6.1.4.1.14988.1.1.3.14.0', 'CPU Frequency'),

    -- Memory
    ('.1.3.6.1.2.1.25.2.3.1.5.65536', 'Total Memory'),
    ('.1.3.6.1.2.1.25.2.3.1.6.65536', 'Use Memory'),
    ('.1.3.6.1.2.1.25.2.3.1.5.131072', 'Total System Disk'),
    ('.1.3.6.1.2.1.25.2.3.1.6.131072', 'Use System Disk');

INSERT INTO master.dbo.OidList (Oid)
OUTPUT INSERTED.ID, INSERTED.Oid INTO @InsertedOid(Id, Oid)
SELECT Oid FROM @Oids1;

INSERT INTO master.dbo.Item (ModelId, ItemName, OidId)
SELECT @ModelId1, o.ItemName, i.Id 
FROM @Oids1 o
JOIN @InsertedOid i ON o.Oid = i.Oid;



