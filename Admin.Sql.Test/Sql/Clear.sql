-- Limpar as Tabelas padrões do Banco
-- Sera executado pelo Start_SQL.sh

USE master;
GO

-- Excluir tabela MSreplication_options, se existir
IF OBJECT_ID('MSreplication_options', 'U') IS NOT NULL
    DROP TABLE MSreplication_options;
GO

-- Excluir todas as tabelas do sistema spt_*, exceto spt_values, se existirem
DECLARE @tableName NVARCHAR(100);
DECLARE @sql NVARCHAR(MAX);

DECLARE tableCursor CURSOR FOR
    SELECT name
    FROM sysobjects
    WHERE xtype = 'U' AND name LIKE 'spt_%' AND name <> 'spt_values'; 

OPEN tableCursor;

FETCH NEXT FROM tableCursor INTO @tableName;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @sql = 'DROP TABLE ' + QUOTENAME(@tableName);
    EXEC sp_executesql @sql;
    FETCH NEXT FROM tableCursor INTO @tableName;
END

CLOSE tableCursor;
DEALLOCATE tableCursor;
GO
